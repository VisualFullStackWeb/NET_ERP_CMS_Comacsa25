Imports SIP_Entidad
Imports SIP_Negocio
Imports Infragistics.Win.UltraWinGrid.UltraGridAction

Public Class FrmIngresoRemarcado

    '   *****       VARIABLES   *****
    Dim Serie As String
    Dim NumeroMovimiento As String
    Dim dtNumeroMovimientoAlmacen As New DataTable
    Dim movimientos As New DataTable
    Dim dtSerie As New DataTable
    Dim xTipoCambio As String
    Dim NumeroInternoMovimiento As String
    Dim xNumeroIngresoXorden As String
    Dim xNumeroInternoIngresoXorden As String

    Public Ls_Permisos As New List(Of Integer)

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Funciones Locales"

    '#Region "Listar Movimientos de Almacén Por Usuario"
    '    Private Sub ListarMovimientosUsuario()
    '        With Entidad.UsersBE
    '            .Cod_Cia = Companhia
    '            .Name_User = gUsuario
    '        End With
    '        CboTipoMovimiento.DataSource = Negocio.MovAlmUserBL.ListarMovimientosUsuarios(Entidad.UsersBE)
    '        CboTipoMovimiento.DisplayMember = "Descripcion"
    '        CboTipoMovimiento.ValueMember = "Codigo"
    '        CboTipoMovimiento.Value = "23"
    '    End Sub
    '#End Region

    '#Region "Listar Almacenes Por Usuario"
    '    Private Sub ListarAlmacenUsuarios()
    '        With Entidad.UsersBE
    '            .Cod_Cia = Companhia
    '            .Name_User = gUsuario
    '        End With
    '        CboAlmacen.DataSource = Negocio.MovAlmUserBL.ListarAlmacenUsuarios(Entidad.UsersBE)
    '        CboAlmacen.DisplayMember = "Descripcion"
    '        CboAlmacen.ValueMember = "Codigo"
    '        CboAlmacen.Value = "28"
    '    End Sub
    '#End Region

#Region "Limpiar"
    Private Sub Limpiar()
        TxtNumeroMovimiento.Clear()
        dtFeStringegistro.Value = Now
        CboAlmacen.Value = 28
        LblEstado.Text = ""
    End Sub
#End Region

#Region "Listar Movimientos Ingreso por Cambio de Producto"
    Private Sub ListarMovimientoIngresoRemarcado(ByVal Documento As String, ByVal Opcion As String)
        With Entidad.Guia
            Dim ab, cd As String
            .Cod_Cia = Companhia
            .NumDoc = Documento
            .Tipo_Doc = "IE"
            .Ano = Year(DtFechaConsulta.Value)
            .User_Crea = User_Sistema
            ab = Month(DtFechaConsulta.Value)
            cd = Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)

            If Len(ab) = 1 Then
                .Mes = "0" & Month(DtFechaConsulta.Value)
            Else
                .Mes = Month(DtFechaConsulta.Value)
            End If

            If Len(cd) = 1 Then
                .Mes = "0" & Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)
            Else
                .Dia = Microsoft.VisualBasic.DateAndTime.Day(DtFechaConsulta.Value)
            End If

        End With
        movimientos = Negocio.Guia.ListarMovimientoPorAjuste(Entidad.Guia, Opcion)
    End Sub
#End Region

#End Region   '   Funciones Locales

#Region "Load"
    Private Sub FrmIngresoRemarcado_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarMovimientosUsuario(CboTipoMovimiento, "23")
        Call ListarAlmacenUsuarios(CboAlmacen, "28")
        Call ListarMovimientoIngresoRemarcado("", "LTO")
        DgvIngresoRemarcado.DataSource = movimientos
        DtFechaConsulta.Value = Now
        dtFeStringegistro.Value = Now
    End Sub
#End Region                '   Load

#Region "Evento Controles"

#Region "DgvIngresoRemarcado_DoubleClickRow"
    Private Sub DgvIngresoRemarcado_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles DgvIngresoRemarcado.DoubleClickRow
        TabIngresoRemarcado.Tabs("Ingreso").Selected = True
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        TxtNumeroMovimiento.Text = e.Row.Cells("NumeroDocumento").Value
        dtFeStringegistro.Value = e.Row.Cells("Fecha").Value
        With Entidad.Guia
            .Cod_Cia = Companhia
            .NumDoc = Trim(TxtNumeroMovimiento.Text & "")
        End With
        dgvDetalleIngresoRemarcado.DataSource = Negocio.Guia.ListarDetalleIngresoRemarcado(Entidad.Guia)
        Call UbicarCursorGrilla(dgvDetalleIngresoRemarcado, dgvDetalleIngresoRemarcado.Rows(0), "Codigo")
    End Sub
#End Region

#Region "dgvDetalleIngresoRemarcado - KeyDown"
    Private Sub dgvDetalleIngresoRemarcado_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvDetalleIngresoRemarcado.KeyDown
        With sender
            Select Case e.KeyValue
                Case Keys.Up
                    .PerformAction(ExitEditMode)
                    .PerformAction(AboveCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Down
                    .PerformAction(ExitEditMode)
                    .PerformAction(BelowCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Right
                    .PerformAction(ExitEditMode)
                    .PerformAction(NextCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Left
                    .PerformAction(ExitEditMode)
                    .PerformAction(PrevCellByTab)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
                Case Keys.Return
                    .PerformAction(ExitEditMode)
                    .PerformAction(BelowCell)
                    e.Handled = Boolean.TrueString
                    .PerformAction(EnterEditMode)
            End Select
        End With
    End Sub
#End Region

#End Region    '   Evento Controles

#Region "Funciones Publicas"
    Public Sub Procesar()
        Call ListarMovimientoIngresoRemarcado("", "LTO")
        DgvIngresoRemarcado.DataSource = movimientos

        TabIngresoRemarcado.Tabs("Listar").Selected = True

    End Sub

#End Region


End Class