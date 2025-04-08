Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Public Class frmSteoFechas
#Region "Declarar Variables"
    Dim objNegocio As NGContratista = Nothing
    Dim objEntidad As ETContratista = Nothing
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
    Private puedeeliminar As Int32 = 0
    Private flgaprobada As Int32 = 0
    Private esCreador As Int32 = 0
    Private esAprobador As Int32 = 0
    Private dias As Int32 = 0
    Dim esprimera As Int32 = 0
    Private lineacredito As Double = 0
    Dim estado As String = String.Empty
    Private montosolicitud As Double = 0
#End Region
    Sub CargarDatos()
        Try
            Dim objNegocio As NGContratista = Nothing
            objNegocio = New NGContratista
            Dim dtContratista As New DataTable
            dtContratista = objNegocio.ListarContratistaConsulta(Companhia, "")
            Call CargarUltraGridxBinding(gridContratista, Source1, dtContratista)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub frmSteoFechas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtayo.Value = Now.Date.Year
        dtinicio.Value = "01/01/" & Now.Date.Year
        CargarDatos()
    End Sub
    Private Sub gridcontratista_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridcontratista.DoubleClickRow
        Try
            txtcodcontratista.Text = gridcontratista.ActiveRow.Cells("COD_PROV").Value.ToString.Trim
            txtcontratista.Text = gridcontratista.ActiveRow.Cells("RAZON").Value.ToString.Trim
            txtruc.Text = gridcontratista.ActiveRow.Cells("RUC").Value.ToString.Trim
            txtid.Text = gridcontratista.ActiveRow.Cells("IDCONTRATISTA").Value
            Me.TabMaestro.Tabs("Registro").Selected = True
        Catch ex As Exception
        End Try
    End Sub
    Private Sub txtayo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtayo.ValueChanged
        dtinicio.Value = "01/01/" & txtayo.Value
    End Sub
End Class