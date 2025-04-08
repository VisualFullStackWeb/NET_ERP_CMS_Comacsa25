Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FrmConsultaEstadoRequisicion

    Public Ls_Permisos As New List(Of Integer)
    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) _
                 Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Administrar_Permisos(MdiParent, Ls_Permisos)

    End Sub

#Region "Load"
    Private Sub FrmConsultaEstadoRequisicion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ListarCia(Cia1)
        Call ListarCia(Cia2)
        Call ListarAlmacen_General(CboAlmacen)
        Call ListarArea_General(CboArea)


        Entidad.Usuario = New ETUsuario
        Negocio.Usuario = New NGUsuario

        With Entidad.Usuario
            .Cod_Cia = Companhia
            .Login = User_Sistema
            .Sistema = Sistema
        End With
        Dim dtDatosUsers As New DataTable
        dtDatosUsers = Negocio.Usuario.ListarUsers(Entidad.Usuario, "DUS")
        gAdmin = dtDatosUsers.Rows(0).Item("Administrador")
        gAreaUsuario = dtDatosUsers.Rows(0).Item("Area")


        Call ListarRequisicion()
    End Sub
#End Region                '   Load

#Region "Funciones Locales"

#Region "Listar Requisicion"
    Private Sub ListarRequisicion()
        With Entidad.Pedido
            .Cod_Cia = Companhia
            .Codigo_Area = gAreaUsuario
        End With
        dgvListarRequisicion.DataSource = Negocio.PedidoBL.Listar_Pedido(Entidad.Pedido, "L3")

    End Sub
#End Region

#End Region   '   Funciones Locales

#Region "Funciones Publicas"
    Public Sub Actualizar()
        Call ListarRequisicion()
    End Sub
#End Region  '   Funciones Publicas

#Region "Evento Controles"

#Region "dgvListarRequisicion - DoubleClickRow"
    Private Sub dgvListarRequisicion_DoubleClickRow(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles dgvListarRequisicion.DoubleClickRow
        TabConsultarEstado.Tabs("Detalle").Selected = True

        LblEmpleo.Visible = False
        TxtCodigoEmpleo.Visible = False
        TxtEmpleo.Visible = False

        LblCantera.Visible = False
        TxtCodigoCantera.Visible = False
        TxtCantera.Visible = False

        LblContratista.Visible = False
        CboContratista.Visible = False

        dtFecha.Value = e.Row.Cells("Fecha").Value
        TxtNumeroRequisicion.Text = e.Row.Cells("Codigo").Value
        TxtUserSolicita.Text = e.Row.Cells("CodigoUsuario").Value
        TxtNombreSolicita.Text = e.Row.Cells("NombreUsuario").Value
        CboAlmacen.Value = e.Row.Cells("CodigoAlmacen").Value
        CboArea.Value = e.Row.Cells("CodigoArea").Value

        If CboArea.Value = 22 Then
            LblEmpleo.Visible = True
            TxtCodigoEmpleo.Visible = True
            TxtEmpleo.Visible = True

            LblCantera.Visible = True
            TxtCodigoCantera.Visible = True
            TxtCantera.Visible = True

            LblContratista.Visible = True
            CboContratista.Visible = True


            TxtCodigoEmpleo.Text = e.Row.Cells("CodigoEmpleo").Value
            TxtEmpleo.Text = e.Row.Cells("EmpleoLabor").Value
            TxtCodigoCantera.Text = e.Row.Cells("CodigoCantera").Value
            TxtCantera.Text = Trim(e.Row.Cells("Cantera").Value & "")
            Call ContratistaCantera(CboContratista, TxtCodigoCantera.Text, CboArea.Value)
            CboContratista.Value = e.Row.Cells("CodigoProveedor").Value
        End If

        dtFechaEntrega.Value = e.Row.Cells("Entrega").Value
        LblEstado.Text = e.Row.Cells("Estado").Value

        With Entidad.Pedido
            .Cod_Cia = Companhia
            .Numero_Doc = TxtNumeroRequisicion.Text
        End With

        dgvListarRequisicion2.DataSource = Negocio.PedidoBL.ListarDetallePedido(Entidad.Pedido, "LCON")

        If dgvListarRequisicion2.Rows.Count > 0 Then
            For K As Integer = 0 To dgvListarRequisicion2.Rows.Count - 1
                If IsDBNull(dgvListarRequisicion2.Rows(K).Cells("SalidaOrden").Value) = True Then
                    dgvListarRequisicion2.Rows(K).Cells("EstadoSO").Value = ""
                End If
            Next
        End If

    End Sub
#End Region

#End Region    '   Evento Controles


End Class