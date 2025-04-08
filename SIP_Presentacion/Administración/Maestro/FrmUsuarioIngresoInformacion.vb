Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmUsuarioIngresoInformacion
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
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
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_EntregaDetalle As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private codsistema As String = String.Empty
#End Region
    Private Sub FrmUsuarioApruebaEntrega_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LlenarTipo()
        CargarAreas()
    End Sub

    Sub LlenarTipo()
        Dim dtTipo As New DataTable
        dtTipo.Columns.Add("DESCRIPCION")
        Dim dr As DataRow
        dr = dtTipo.NewRow
        dr(0) = "SOLICITUD"
        dtTipo.Rows.Add(dr)
        dr = dtTipo.NewRow
        dr(0) = "LIQUIDACION"
        dtTipo.Rows.Add(dr)
        cmbTipo.DataSource = dtTipo
    End Sub

    Private Sub cmbArea_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbArea.InitializeLayout
        With cmbArea.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("Area").Width = 300 'sender.Width
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "Area") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub
 
    Sub SubProceso_UsuariosAprueba(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        Ope = 2
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Call HabilitarControles(True)
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        cmbArea.Value = uRow.Cells("codArea").Value.ToString.Trim
        TxtUsuario.Text = uRow.Cells("Usuario").Value.ToString.Trim
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Private Sub CargarAreas()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarAreas
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraCombo(cmbArea, Ls_Entrega, "codArea", "Area")
    End Sub
    Private Sub GridUsuariosAprueba_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Usuario" OrElse uColumn.Key = "tipoAprobacion" OrElse uColumn.Key = "Area" OrElse uColumn.Key = "Descripcion") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Private Sub cmbArea_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbArea.ValueChanged
        Try
            'TxtUsuario.Focus()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub Nuevo()
        Call LimpiarDatos()
        Call HabilitarControles(False)
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Ope = 1
    End Sub
    Private Sub LimpiarDatos()
        Me.TxtUsuario.Clear()
        cmbArea.Value = 0
        cmbTipo.Value = 0
        Me.ChkMarcarTodo.Checked = False
        Ep1.Clear()
        Ope = 0
    End Sub
    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.TxtUsuario.ReadOnly = D
        Me.cmbArea.ReadOnly = D
    End Sub
    Sub cancelar()
        Call LimpiarDatos()
        Call HabilitarControles(True)
    End Sub
    Sub actualizar()
        Call LimpiarDatos()
        Call HabilitarControles(True)
    End Sub
    Sub modificar()
        If Ope = 1 Then Return
        Call HabilitarControles(False)
    End Sub
    Sub buscar()
        'If TxtUsuario.ReadOnly = True Then Return
        codsistema = "22"
        Dim FRM As New FrmCargarUsuario
        FRM.sistema = codsistema
        FRM.ShowDialog()
        TxtUsuario.Text = userLogin.ToString.Trim
        Ep1.Clear()
        CargarAreaPermiso()
    End Sub
    Private Sub TxtUsuario_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUsuario.KeyDown
        'buscar()
    End Sub
    Private Sub TxtUsuario_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUsuario.KeyPress
        TxtUsuario.Text = String.Empty
    End Sub
    Public Sub Grabar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Ls_Entrega = New List(Of ETEntregas)
        Dim tipoAprobacion As Int32 = 0
        gridArea.PerformAction(ExitEditMode)
        gridArea.PerformAction(EnterEditMode)

        If cmbTipo.Value = "SOLICITUD" Then
            tipoAprobacion = 1
        Else
            tipoAprobacion = 2
        End If

        For j As Integer = 0 To gridArea.Rows.Count - 1

            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = 1
            Entidad.Entregas.userlogin = IIf(TxtUsuario.Value Is Nothing, String.Empty, TxtUsuario.Value.ToString.Trim)
            Entidad.Entregas.codArea = gridArea.Rows(j).Cells("codArea").Value.ToString.Trim 'IIf(cmbArea.Value Is Nothing, String.Empty, cmbArea.Value.ToString.Trim)
            Entidad.Entregas.tipoAprobacion = tipoAprobacion.ToString.Trim
            Entidad.Entregas.Usuario = User_Sistema
            Ls_Entrega.Add(Entidad.Entregas)
            If gridArea.Rows(j).Cells("Action").Value = True Then
                Entidad.Entregas.check = 1
            Else
                Entidad.Entregas.check = 2
            End If

        Next
        Entidad.Entregas = Negocio.NEntregas.MantenimientoUsuarioIngreso(Entidad.Entregas, Ls_Entrega)
        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
    End Sub
    Function Verificar_Datos() As Boolean
        Ep1.Clear()
        Dim lResult As Boolean = Boolean.TrueString
        If String.IsNullOrEmpty(TxtUsuario.Value) Then
            Ep1.SetError(TxtUsuario, "Ingrese usuario")
            lResult = Boolean.FalseString
        End If
        If String.IsNullOrEmpty(cmbTipo.Value) Then
            Ep1.SetError(cmbTipo, "Seleccione TIPO iNGRESO")
            lResult = Boolean.FalseString
        End If
        Return lResult
    End Function
    Sub eliminar()

    End Sub
    Private Sub gridArea_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridArea.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Action" OrElse uColumn.Key = "Area") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub
    Private Sub ChkMarcarTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcarTodo.CheckedChanged
        If gridArea.Rows.Count > 0 Then
            If ChkMarcarTodo.Checked = True Then
                For j As Integer = 0 To gridArea.Rows.Count - 1
                    gridArea.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To gridArea.Rows.Count - 1
                    gridArea.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub

    Private Sub cmbTipo_InitializeLayout1(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles cmbTipo.InitializeLayout
        With cmbTipo.DisplayLayout.Bands(0)
            .ColHeadersVisible = Boolean.FalseString
            .Columns("DESCRIPCION").Width = 220
            For Each uColumn As UltraGridColumn In .Columns
                If Not (uColumn.Key = "DESCRIPCION") Then
                    uColumn.Hidden = Boolean.TrueString
                Else
                    uColumn.Hidden = Boolean.FalseString
                End If
            Next
        End With
    End Sub

    Private Sub CargarAreaPermiso()
        Entidad.Entregas = New ETEntregas
        Entidad.Entregas.TipoOperacion = Ope
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Ls_EntregaDetalle = Nothing
        Ls_EntregaDetalle = New List(Of ETEntregas)
        Entidad.Entregas.userlogin = TxtUsuario.Text.ToString.Trim
        Dim tipoAprobacion As Int32 = 0
        If cmbTipo.Value = "SOLICITUD" Then
            tipoAprobacion = 1
        Else
            tipoAprobacion = 2
        End If
        Entidad.Entregas.tipoAprobacion = tipoAprobacion.ToString.Trim
        Entidad.MyLista = Negocio.NEntregas.ListarAreasIngreso(Entidad.Entregas)
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridArea, Source2, Ls_Entrega)
    End Sub

    Private Sub cmbTipo_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.ValueChanged
        Try
            CargarAreaPermiso()
        Catch ex As Exception

        End Try
    End Sub
End Class