Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRptCancelacionAnt
    Dim ReportesBL As New NGReportes
    Public flgprovision As String = "0"
    Public ayo As Int32 = 0
    Public mes As Int32 = 0
    Public cgvoucher As String = ""
    Public voucherconta As String = ""

    Private Sub FrmRptRegCompra_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.P And e.Modifiers = Keys.Control) Then
                ReporteRegCompras.PrintReport()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmRptRegCompra_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call Iniciar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Iniciar()
        Try
            Dim ds1 As New DataSet
            Dim Listar As New Crp_Cancela_Ant
            ds1 = ReportesBL.RptCancelaAnt(ayo, mes, cgvoucher, voucherconta, User_Sistema)
            Listar.SetDataSource(ds1.Tables(0))
            ReporteRegCompras.ReportSource = Listar
            ReporteRegCompras.Zoom(1)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

End Class