Imports SIP_Entidad
Imports SIP_Negocio
Imports System
Imports System.Windows.Forms
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win.UltraWinGrid.UltraGridAction
Imports System.IO
Imports System.Text
Public Class frmCamionReprogramacion
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
    Public fecha As DateTime
    Public codprov As String
    Dim dtCamion As New DataTable
    Public placa As String = ""
    Private Sub frmCamionReprogramacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        placa = ""
        Entidad.Contratista = New ETContratista
        Entidad.Contratista.TipoOperacion = Ope
        Negocio.NContratista = New NGContratista
        Entidad.MyLista = New ETMyLista
        Entidad.Contratista.Usuario = User_Sistema
        Entidad.Contratista._codprov = codprov
        Entidad.Contratista.Fecha = fecha
        Entidad.Contratista.NroViaje = 1
        dtCamion = Negocio.NContratista.Listar_PRO_CamionDisponible(Entidad.Contratista)
        If dtCamion.Rows.Count <= 0 Then
            MsgBox("No existen camiones disponibles para la fecha " & fecha.ToString("dd/MM/yyyy"), MsgBoxStyle.Exclamation, msgComacsa)
            Me.Close()
        End If
        Call CargarUltraGridxBinding(Me.gridCamiones, Source2, dtCamion)
    End Sub

    Private Sub gridCamiones_DoubleClickRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles gridCamiones.DoubleClickRow
        Try
            placa = gridCamiones.ActiveRow.Cells("PLACA").Value.ToString.Trim
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
End Class