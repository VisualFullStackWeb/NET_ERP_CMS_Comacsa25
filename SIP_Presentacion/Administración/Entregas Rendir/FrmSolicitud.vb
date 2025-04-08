Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSolicitud
    Dim ReportesBL As New NGReportes
    Dim tblSolicitud As DataTable = Nothing
    Sub Iniciar()
        Try
            Dim ds1 As New DataSet
            Dim Listar As New Crp_Solicitud
            ds1 = ReportesBL.RptSolicitud(nroSolicitud)
            Listar.SetDataSource(ds1.Tables(0))
            ReporteSolicitud.ReportSource = Listar
            ReporteSolicitud.Zoom(1)
            'Listar.PrintOptions.PrinterName = "FX890B"
            'MsgBox(Listar.PrintOptions.PrinterName)
            'Listar.PrintToPrinter(1, True, 0, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub

    Private Sub FrmSolicitud_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.P And e.Modifiers = Keys.Control) Then
                ReporteSolicitud.PrintReport()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmSolicitud_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Iniciar()
    End Sub
End Class