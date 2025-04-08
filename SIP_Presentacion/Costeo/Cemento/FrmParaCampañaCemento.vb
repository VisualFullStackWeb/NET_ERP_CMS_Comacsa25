Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Imports Microsoft.Office.Interop
Public Class FrmParaCampañaCemento
#Region "Declarar Variables"
    Dim lResult As ETMyLista = Nothing
    Public Ls_Permisos As New List(Of Integer)
    Private Ope As Int32 = 0
    Dim NumSolicitud As String = String.Empty
    Private Ls_Entrega As List(Of ETEntregas) = Nothing
    Private Ls_DetalleComp As List(Of ETEntregas) = Nothing
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Public ConceptoSeleccionado As String
    Public filtroDescripcion As String = String.Empty
#End Region
    Dim _objNegocio As NGProducto
    Dim _objEntidad As ETProducto

    Private Sub FrmParaCampañaCemento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargaDatos()
    End Sub
    Sub cargaDatos()
        Dim dtDatos As New DataTable
        dtDatos = New DataTable
        _objNegocio = New NGProducto
        _objEntidad = New ETProducto
        dtDatos = _objNegocio.LISTA_PARA_CAMPANIA(_objEntidad)
        Call CargarUltraGridxBinding(Me.gridCampania, Source1, dtDatos)
    End Sub
    Sub Nuevo()
        Dim frm As New FrmIngresaCampaña
        frm.dtpInicio.Value = Now.Date
        frm.dtpFin.Value = Now.Date
        frm.ShowDialog()
        cargaDatos()
    End Sub

    Sub Eliminar()
        Try
            Dim dtDatos As New DataTable
            dtDatos = New DataTable
            _objNegocio = New NGProducto
            _objEntidad = New ETProducto
            _objEntidad.ID = gridCampania.ActiveRow.Cells("ID").Value
            _objEntidad.FechaInicio = gridCampania.ActiveRow.Cells("FECHAINICIO").Value
            _objEntidad.FechaTerminacion = gridCampania.ActiveRow.Cells("FECHAFIN").Value
            _objEntidad.Tipo = 3
            _objEntidad.numdoc = gridCampania.ActiveRow.Cells("NOMBRE").Value
            _objEntidad.CodEquipo = gridCampania.ActiveRow.Cells("COD_EQUIPO").Value
            _objEntidad.Equipo = gridCampania.ActiveRow.Cells("EQUIPO").Value
            dtDatos = _objNegocio.MANT_PARA_CAMPANIA(_objEntidad)
            If dtDatos.Rows(0)(0) = "OK" Then
                MsgBox("Eliminado Correctamente", MsgBoxStyle.Information, "Aviso")
                cargaDatos()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub gridCampania_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridCampania.DoubleClick
        Dim frm As New FrmIngresaCampaña
        frm.txtid.Text = gridCampania.ActiveRow.Cells("ID").Value
        frm.txtnumero.Text = gridCampania.ActiveRow.Cells("NOMBRE").Value
        frm.txtcodequipo.Text = gridCampania.ActiveRow.Cells("COD_EQUIPO").Value
        frm.txtequipo.Text = gridCampania.ActiveRow.Cells("EQUIPO").Value
        frm.dtpInicio.Value = gridCampania.ActiveRow.Cells("FECHAINICIO").Value
        frm.dtpFin.Value = gridCampania.ActiveRow.Cells("FECHAFIN").Value
        frm.ShowDialog()
        cargaDatos()
    End Sub

    Private Sub gridCampania_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles gridCampania.InitializeLayout

    End Sub
End Class