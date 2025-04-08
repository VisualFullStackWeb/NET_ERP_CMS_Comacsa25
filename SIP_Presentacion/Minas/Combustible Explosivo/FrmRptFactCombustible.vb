Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRptFactCombustible
    Dim ReportesBL As New NGReportes
    Dim tblSolicitud As DataTable = Nothing
    Public id As Int32 = 0
    Sub Iniciar()
        Try
            Dim ds1 As New DataSet
            Dim Listar As New Crp_FactCombustible
            ds1 = ReportesBL.RptFactCombustible(id)
            Listar.SetDataSource(ds1.Tables(0))
            ReporteSolicitud.ReportSource = Listar
            ReporteSolicitud.Zoom(1)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub FrmRptFactCombustible_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.P And e.Modifiers = Keys.Control) Then
                ReporteSolicitud.PrintReport()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmRptFactCombustible_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Iniciar()
    End Sub
End Class