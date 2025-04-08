Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Frm_RptAsientoProvision
    Dim ReportesBL As New NGReportes
    Dim tblSolicitud As DataTable = Nothing
    Public esDevolucion As Int32 = 0
    Public voucherconta As String
    Public cgvoucher As String
    Public año As String
    Public mes As String
    Public ds1 As New DataSet
    Private Sub Frm_RptAsientoProvision_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call Iniciar()
    End Sub
    Sub Iniciar()
        Try

            Dim Listar As New Crp_AsientoEntregas

            Listar.SetDataSource(ds1.Tables(0))
            ReporteReintegro.ReportSource = Listar
            ReporteReintegro.Zoom(1)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class