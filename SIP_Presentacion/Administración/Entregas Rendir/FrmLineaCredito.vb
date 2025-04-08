Imports SIP_Entidad
Imports SIP_Negocio
Imports System

Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmLineaCredito
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
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    'Private ctabeneficiario As String = String.Empty
    'Private bcotra As String = String.Empty
#End Region
    Private Sub FrmLineaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call HabilitarControles(False)
        Call CargarDatos()
    End Sub
    Private Sub CargarDatos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Entidad.MyLista = Negocio.NEntregas.ListarLineacredito()
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.Gridlineacredito, Source1, Ls_Entrega)
    End Sub
    Private Sub TxtCodigoTrabajador_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTrabajador.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If TxtCodigoTrabajador.Text.ToString.Trim = "" Then
            TxtCodigoTrabajador.Focus()
            Exit Sub
        End If
        CargarTrabajadoresxCodigo(Me.TxtCodigoTrabajador.Text)
        If lResult.Ls_Entrega.Count > 0 Then
            TxtNombresTrabajador.Text = lResult.Ls_Entrega.Item(0).NomTrabajador
            TxtLineaCredito.ReadOnly = False
            TxtLineaCredito.Focus()
        Else
            MsgBox("Código de trabajador no existe", MsgBoxStyle.Exclamation, msgComacsa)
            TxtCodigoTrabajador.Clear()
            TxtNombresTrabajador.Clear()
            TxtCodigoTrabajador.Focus()
        End If
    End Sub
    Private Sub CargarTrabajadoresxCodigo(ByVal codTrabajador As String)
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = codTrabajador
        Entidad.MyLista = Negocio.NEntregas.ListarTrabajadorxCodigo(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
    End Sub

    Sub buscar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If TxtCodigoTrabajador.ReadOnly = True Then Return
        Dim FRM As New FrmListadoPersonal
        FRM.ShowDialog()
        If codTrabajador.ToString.Trim = "" Then Return
        TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
        TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
        TxtLineaCredito.Focus()
        TxtLineaCredito.ReadOnly = False
    End Sub

    Public Sub Nuevo()
        Ope = 1
        nroSolicitud = String.Empty
        Call LimpiarDatos()
        Call HabilitarControles(True)
        Ep1.Clear()
        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Me.TxtCodigoTrabajador.Focus()
    End Sub
    Sub LimpiarDatos()
        TxtCodigoTrabajador.Clear()
        TxtNombresTrabajador.Clear()
        TxtLineaCredito.Clear()
        codTrabajador = String.Empty
        nomTrabajador = String.Empty
        chklimite.Checked = False
    End Sub
    Private Sub HabilitarControles(ByVal D As Boolean)
        Me.TxtCodigoTrabajador.ReadOnly = Not D
        Me.TxtNombresTrabajador.ReadOnly = D
        Me.TxtLineaCredito.ReadOnly = D
    End Sub

    Private Sub TxtLineaCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtLineaCredito.KeyPress
        e.Handled = txtNumerico(sender, e.KeyChar, True)
    End Sub

    Public Sub Grabar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Ope = 0 Then
            MessageBox.Show(Mensaje.Seleccion, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.Entregas.TipoOperacion = 1
        Entidad.Entregas.CodTrabajador = IIf(TxtCodigoTrabajador.Value Is Nothing, String.Empty, TxtCodigoTrabajador.Value)
        Entidad.Entregas.lineacredito = IIf(TxtLineaCredito.Value Is Nothing, String.Empty, CDbl(TxtLineaCredito.Value))
        Entidad.Entregas.permiso = IIf(chklimite.Checked = True, 1, 0)
        Entidad.Entregas.Usuario = User_Sistema
        Entidad.Entregas = Negocio.NEntregas.MantenimientoLineacredito(Entidad.Entregas, Ls_Entrega, Ls_EntregaDetalle)

        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
        'Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub

    Function Verificar_Datos() As Boolean

        Ep1.Clear()

        Dim lResult As Boolean = Boolean.TrueString

        CargarTrabajadoresxCodigo(Me.TxtCodigoTrabajador.Text)
        If Not Ls_Entrega.Count > 0 Then
            'MsgBox("Código de trabajador no existe", MsgBoxStyle.Exclamation, msgComacsa)
            TxtCodigoTrabajador.Clear()
            TxtNombresTrabajador.Clear()
            TxtCodigoTrabajador.Focus()
            'lResult = Boolean.FalseString
        End If
        If String.IsNullOrEmpty(TxtCodigoTrabajador.Value) Then
            Ep1.SetError(TxtCodigoTrabajador, "Ingrese código de trabajador")
            lResult = Boolean.FalseString
        End If
        If String.IsNullOrEmpty(TxtLineaCredito.Value) Then
            Ep1.SetError(TxtLineaCredito, "Ingrese linea de crédito")
            lResult = Boolean.FalseString
        End If

        Return lResult

    End Function

    Sub actualizar()
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Call CargarDatos()
        TabMaestroEntregas.Tabs("lista").Selected = Boolean.TrueString
        LimpiarDatos()
        HabilitarControles(True)
        TxtCodigoTrabajador.ReadOnly = True
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)
    End Sub
    Sub cancelar()
        TabMaestroEntregas.Tabs("lista").Selected = Boolean.TrueString
        LimpiarDatos()
        HabilitarControles(True)
        TxtCodigoTrabajador.ReadOnly = True
    End Sub

    Private Sub Gridlineacredito_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles Gridlineacredito.DoubleClickRow
        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If sender IsNot Gridlineacredito Then Return

        If e.Row.IsFilterRow Then Return

        SubProceso_Lineacredito(e.Row)
    End Sub

    Sub SubProceso_Lineacredito(ByVal uRow As UltraGridRow)
        If uRow Is Nothing Then
            Return
        End If
        Ope = 2
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista

        Call HabilitarControles(True)
        Me.TxtCodigoTrabajador.ReadOnly = True
        Call CargarUltraStatusBar(MdiParent, uStatus.Procesando)
        Entidad.MyLista = New ETMyLista
        TxtCodigoTrabajador.Value = uRow.Cells("CodTrabajador").Value.ToString.Trim
        TxtNombresTrabajador.Value = uRow.Cells("NomTrabajador").Value.ToString.Trim
        TxtLineaCredito.Text = uRow.Cells("lineacredito").Value.ToString.Trim
        If uRow.Cells("permiso").Value.ToString.Trim = 1 Then
            chklimite.Checked = True
        Else
            chklimite.Checked = False
        End If

        TabMaestroEntregas.Tabs("Registro").Selected = Boolean.TrueString
        Call CargarUltraStatusBar(MdiParent, uStatus.Finalizado)

    End Sub

    Private Sub Gridlineacredito_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles Gridlineacredito.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "CodTrabajador" OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "lineacredito") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Sub modificar()
        If Ope <> 2 Then Return
        Call HabilitarControles(False)
        Me.TxtCodigoTrabajador.ReadOnly = False
    End Sub
    Sub eliminar()
        If Ope <> 2 Then Return
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Entidad.Entregas = New ETEntregas
        Negocio.NEntregas = New NGEntregas
        Entidad.Entregas.TipoOperacion = 3
        Entidad.Entregas.CodTrabajador = IIf(TxtCodigoTrabajador.Value Is Nothing, String.Empty, TxtCodigoTrabajador.Value)
        Entidad.Entregas.lineacredito = IIf(TxtLineaCredito.Value Is Nothing, String.Empty, CDbl(TxtLineaCredito.Value))

        Entidad.Entregas = Negocio.NEntregas.EliminarLineacredito(Entidad.Entregas, Ls_Entrega, Ls_EntregaDetalle)

        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
    End Sub

    Private Sub TxtLineaCredito_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtLineaCredito.ValueChanged

    End Sub
End Class