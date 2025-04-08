Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRptLiquidacion
    Dim ReportesBL As New NGReportes
    Dim tblSolicitud As DataTable = Nothing
    Public esDevolucion As Int32 = 0
    Public tiporeporte As Int32 = 0

    Public reporteconta As Int32 = 0
    Sub Iniciar()
        Try
            Dim ds1 As New DataSet
            Dim ds2 As New DataSet

            Dim Listar As New Crp_Liquidacion1
            Dim Listar1 As New Crp_Liquidacion1

            If tiporeporte = 0 Then
                If esDevolucion = 0 Then
                    ds1 = ReportesBL.RptLiquidacion(nroSolicitud)
                    ds2 = ReportesBL.RptLiquidacionDet(nroSolicitud)
                Else
                    ds1 = ReportesBL.RptLiquidacionPend(nroSolicitud)
                End If
                Listar.SetDataSource(ds1.Tables(0))

                If ds2.Tables.Count > 0 Then
                    If Listar.Subreports.Count > 0 Then
                        Listar.Subreports(0).SetDataSource(ds2.Tables(0))
                    Else
                        MsgBox("No se encontraron subreportes en el informe.")
                    End If
                Else
                    MsgBox("No se encontraron datos en DS2.")
                End If

                'Listar.Subreports(0).SetDataSource(ds2.Tables(0))

                ReporteLiquidacion.ReportSource = Listar
            Else
                If esDevolucion = 0 Then
                    ds1 = ReportesBL.RptLiquidacionCopia(nroSolicitud, reporteconta)
                    ds2 = ReportesBL.RptLiquidacionDet(nroSolicitud)
                Else
                    ds1 = ReportesBL.RptLiquidacionPendCopia(nroSolicitud)
                    ds2 = ReportesBL.RptLiquidacionDet(nroSolicitud)
                End If
                If reporteconta = 1 Then
                    Listar1.SetDataSource(ds1.Tables(0))
                    ReporteLiquidacion.ReportSource = Listar1
                Else
                    Listar.SetDataSource(ds1.Tables(0))
                    Listar.Subreports(0).SetDataSource(ds2.Tables(0))
                    ReporteLiquidacion.ReportSource = Listar
                End If
            End If
            ReporteLiquidacion.Zoom(1)
        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub

    Private Sub FrmRptLiquidacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.P And e.Modifiers = Keys.Control) Then
                ReporteLiquidacion.PrintReport()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub FrmLiquidacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call Iniciar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class