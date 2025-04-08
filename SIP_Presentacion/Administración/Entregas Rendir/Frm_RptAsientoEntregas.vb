Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class Frm_RptAsientoEntregas
    Dim ReportesBL As New NGReportes
    Dim tblSolicitud As DataTable = Nothing
    Public esDevolucion As Int32 = 0
    Public voucherconta As String
    Public cgvoucher As String
    Public año As String
    Public mes As String
    Private Sub Frm_RptAsientoEntregas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Iniciar()
    End Sub
    Sub Iniciar()
        Try
            Dim ds1 As New DataSet
            Dim Listar As New Crp_AsientoEntregas

            If esDevolucion = 0 Then
                ds1 = ReportesBL.RptAsientoEntreas(voucherconta, cgvoucher, año, mes)
            Else
                ds1 = ReportesBL.RptAsientoEntreas(voucherconta, cgvoucher, año, mes)
            End If

            Listar.SetDataSource(ds1.Tables(0))
            ReporteReintegro.ReportSource = Listar
            ReporteReintegro.Zoom(1)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class