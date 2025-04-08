Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRptPedido
    Dim ReportesBL As New NGReportes
    Public id As Int32 = 0

    Private Sub FrmRptPedido_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If (e.KeyCode = Keys.P And e.Modifiers = Keys.Control) Then
                ReporteProductoNC.PrintReport()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmRptPedido_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Call Iniciar()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Iniciar()
        Try
            Dim ds1 As New DataSet
            Dim Listar As New Crp_PedidoAlmacen

            ds1 = ReportesBL.RptPedidoSuministro(id)
            'If ds1.Tables(0).Rows.Count <= 0 And ds2.Tables(0).Rows.Count <= 0 Then
            '    MsgBox("No existen datos para mostrar", MsgBoxStyle.Information, "Aviso")
            '    'Me.Close()
            'End If

            Listar.SetDataSource(ds1.Tables(0))
            ReporteProductoNC.ReportSource = Listar
            ReporteProductoNC.Zoom(1)

        Catch ex As Exception
            MsgBox(ex.ToString())
        End Try
    End Sub
End Class