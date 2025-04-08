Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.Data.OleDb
Public Class frmAgregaAlmacen
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
    Sub Nuevo()
        Me.Tab1.Tabs("T02").Selected = True
        Ope = 1
        limpiar()
        txtalmacen.Focus()
    End Sub
    Sub limpiar()
        txtalmacen.Clear()
        txtcodcantera.Clear()
        txtcantera.Clear()
        txtidalmacen.Text = 0
    End Sub

    Private Sub frmAgregaAlmacen_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)
    End Sub

    Private Sub frmAgregaAlmacen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        limpiar()
        CargarDatos()
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
            Entidad.Contratista.ID = txtidalmacen.Text
            Entidad.Contratista._descripcion = txtalmacen.Text
            Entidad.Contratista._codcantera = txtcodcantera.Text
            Entidad.Contratista._flgcontratista = IIf(chkcontratista.Checked = True, 1, 0)
            Entidad.Contratista._usuario = User_Sistema
            Entidad.Contratista = Negocio.NContratista.MantenimientoAlmacen(Entidad.Contratista)
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
        If txtalmacen.Text.ToString.Trim = "" Then
            MsgBox("Ingrese almacén", MsgBoxStyle.Exclamation, msgComacsa)
            txtalmacen.Focus()
            Return False
        End If
        If txtcodcantera.Text.ToString.Trim = "" Then
            MsgBox("Ingrese cantera", MsgBoxStyle.Exclamation, msgComacsa)
            txtcodcantera.Focus()
            Return False
        End If
     
        Return True
    End Function

    Sub Eliminar()
        Try
            If Tab1.SelectedTab.Key <> "T02" Then Return
            If txtidalmacen.Text = 0 Then MsgBox("Seleccione registro a eliminar", MsgBoxStyle.Exclamation, msgComacsa) : Return
            'If Ope = 0 Then
            '    MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Return
            'End If
            'If Not validaDatos() Then
            '    Exit Sub
            'End If
            Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
            Entidad.Contratista = New ETContratista
            Negocio.NContratista = New NGContratista
            Entidad.Contratista.TipoOperacion = 3
            Entidad.Contratista.ID = txtidalmacen.Text
            Entidad.Contratista._descripcion = txtalmacen.Text
            Entidad.Contratista._codcantera = txtcodcantera.Text
            Entidad.Contratista._usuario = User_Sistema
            Entidad.Contratista = Negocio.NContratista.MantenimientoAlmacen(Entidad.Contratista)
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
    Sub CargarDatos()
        objNegocio = New NGContratista
        objEntidad = New ETContratista
        Dim dtDatos As New DataTable
        dtDatos = objNegocio.ListarAlmacen()
        Call CargarUltraGridxBinding(gridAlmacen, Source1, dtDatos)
    End Sub
    Sub Buscar()
        If txtcodcantera.Focused = True Or txtcantera.Focused = True Then
            Dim frm As New frmBuscarCantera
            frm.codprov = ""
            frm.ShowDialog()
            txtcodcantera.Text = frm.gridcontratista.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Text = frm.gridcontratista.ActiveRow.Cells("DESCRIPCION").Value.ToString.Trim
        End If
    End Sub

    Private Sub gridAlmacen_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridAlmacen.DoubleClickRow
        Try
            txtalmacen.Text = gridAlmacen.ActiveRow.Cells("ALMACEN").Value
            txtcodcantera.Text = gridAlmacen.ActiveRow.Cells("CODCANTERA").Value.ToString.Trim
            txtcantera.Value = gridAlmacen.ActiveRow.Cells("CANTERA").Value
            txtidalmacen.Value = gridAlmacen.ActiveRow.Cells("ID").Value
            If gridAlmacen.ActiveRow.Cells("FLGCONTRATISTA").Value = 1 Then
                chkcontratista.Checked = True
            Else
                chkcontratista.Checked = False
            End If
            Me.Tab1.Tabs("T02").Selected = True
            txtalmacen.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridAlmacen_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridAlmacen.InitializeLayout

    End Sub
End Class