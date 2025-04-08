Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports Infragistics
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class FrmSeteoEnvioCorreo
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

    End Sub

    Private Sub TxtCodigoTrabajador_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCodigoTrabajador.KeyDown
        If Not (e.KeyValue = Keys.Enter OrElse e.KeyValue = Keys.Tab) Then Return
        If sender.readonly = True Then Return
        If TxtCodigoTrabajador.Text.ToString.Trim = "" Then
            TxtCodigoTrabajador.Focus()
            Exit Sub
        End If
        CargarTrabajadoresxCodigo(Me.TxtCodigoTrabajador.Text)
        If lResult.Ls_Entrega.Count > 0 Then
            TxtNombresTrabajador.Text = lResult.Ls_Entrega.Item(0).NomTrabajador
            cargar_datos()
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
        If TxtCodigoTrabajador.Focused = True Then
            Dim FRM As New FrmListadoPersonal
            FRM.ShowDialog()
            If codTrabajador.ToString.Trim = "" Then Return
            TxtCodigoTrabajador.Text = codTrabajador.ToString.Trim
            TxtNombresTrabajador.Text = nomTrabajador.ToString.Trim
            cargar_datos()
        End If

    End Sub
    Sub cargar_datos()
        Negocio.NEntregas = New NGEntregas
        Entidad.MyLista = New ETMyLista
        Ls_Entrega = Nothing
        Ls_Entrega = New List(Of ETEntregas)
        Dim Rpt As New ETEntregas
        Rpt.CodTrabajador = TxtCodigoTrabajador.Text.Trim
        Entidad.MyLista = Negocio.NEntregas.ListarSeteoCorreo(Rpt)
        lResult = New ETMyLista
        lResult = Entidad.MyLista
        If Entidad.MyLista.Validacion Then
            Ls_Entrega = Entidad.MyLista.Ls_Entrega
        End If
        Call CargarUltraGridxBinding(Me.gridSeteo, Source1, Ls_Entrega)
    End Sub

    Private Sub gridSeteo_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridSeteo.InitializeLayout
        For Each uColumn As UltraGridColumn In e.Layout.Bands(0).Columns
            If Not (uColumn.Key = "Action" OrElse uColumn.Key = "CodJefe" OrElse uColumn.Key = "NomTrabajador" OrElse uColumn.Key = "Email") Then
                uColumn.Hidden = Boolean.TrueString
            Else
                uColumn.Hidden = Boolean.FalseString
            End If
        Next
    End Sub

    Private Sub ChkMarcarTodo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMarcarTodo.CheckedChanged
        If gridSeteo.Rows.Count > 0 Then
            If ChkMarcarTodo.Checked = True Then
                For j As Integer = 0 To gridSeteo.Rows.Count - 1
                    gridSeteo.Rows(j).Cells("Action").Value = True
                Next
            Else
                For j As Integer = 0 To gridSeteo.Rows.Count - 1
                    gridSeteo.Rows(j).Cells("Action").Value = False
                Next
            End If
        End If
    End Sub

    Public Sub Grabar()
        If TabMaestroEntregas.SelectedTab.Key <> "Registro" Then Return
        If Not Verificar_Datos() Then
            MessageBox.Show(Mensaje.Error01, Mensaje.Comacsa, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Ls_Entrega = New List(Of ETEntregas)
        Dim tipoAprobacion As Int32 = 0
        gridSeteo.PerformAction(ExitEditMode)
        gridSeteo.PerformAction(EnterEditMode)


        For j As Integer = 0 To gridSeteo.Rows.Count - 1

            Entidad.Entregas = New ETEntregas
            Entidad.Entregas.TipoOperacion = 1
            Entidad.Entregas.CodTrabajador = IIf(TxtCodigoTrabajador.Value Is Nothing, String.Empty, TxtCodigoTrabajador.Value.ToString.Trim)
            Entidad.Entregas.CodJefe = gridSeteo.Rows(j).Cells("CodJefe").Value.ToString.Trim
            Entidad.Entregas.Email = gridSeteo.Rows(j).Cells("Email").Value.ToString.Trim
            Ls_Entrega.Add(Entidad.Entregas)
            If gridSeteo.Rows(j).Cells("Action").Value = True Then
                Entidad.Entregas.check = 1
            Else
                Entidad.Entregas.check = 2
            End If

        Next
        Entidad.Entregas = Negocio.NEntregas.MantenimientoSeteoCorreo(Entidad.Entregas, Ls_Entrega)
        If Entidad.Entregas.Validacion Then
            Call actualizar()
        End If
    End Sub
    Function Verificar_Datos() As Boolean
        Ep1.Clear()
        Dim lResult As Boolean = Boolean.TrueString
        If String.IsNullOrEmpty(TxtCodigoTrabajador.Value) Then
            Ep1.SetError(TxtCodigoTrabajador, "Ingrese Trabajador")
            lResult = Boolean.FalseString
        End If
       
        Return lResult
    End Function
    Sub actualizar()
        Call LimpiarDatos()
    End Sub
    Private Sub LimpiarDatos()
        Me.TxtCodigoTrabajador.Clear()
        Me.TxtNombresTrabajador.Clear()
        Me.ChkMarcarTodo.Checked = False
        Ep1.Clear()
        cargar_datos()
        Ope = 0
    End Sub
End Class