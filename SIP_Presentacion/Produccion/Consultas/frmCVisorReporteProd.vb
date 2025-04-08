Public Class frmCVisorReporteProd
    Public Ls_Permisos As New List(Of Integer)
    Private Ruta As String = String.Empty
    Private Reporte As New CrystalDecisions.CrystalReports.Engine.ReportDocument

    Private Sub frmCVisorReporteProd_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = ".::: Costeo de Producción :::."
        Dim dsRep As DataSet
        'Dim dsSubRep1 As DataSet
        Dim Fecha1 As DateTime
        Dim Fecha2 As DateTime
        Fecha1 = "01/07/2011 12:00:00 am"
        Fecha2 = "31/07/2011 11:59:59 pm"
        Entidad.Orden.FechaInicio = Fecha1
        Entidad.Orden.FechaTerminacion = Fecha2
        dsRep = Negocio.CosteoProduccion.Consultar_Produccion(Entidad.Orden)
        Ruta = My.Application.Info.DirectoryPath
        Ruta = Ruta + "\Reportes\Produccion\RptCosteoProduccion.rpt"

        Reporte.Load(Ruta, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        Reporte.OpenSubreport("Costeo Producto Ruma")
        Reporte.SetDatabaseLogon("SA", "123", Servidor_App, BD_App)
        'With Reporte.Database.Tables(0).LogOnInfo.ConnectionInfo
        '    .ServerName = Servidor_App
        '    .DatabaseName = BD_App
        '    .UserID = "SA"
        '    .Password = "123"
        '    .IntegratedSecurity = True
        'End With

        Reporte.SetDataSource(dsRep.Tables(0))
        Reporte.Refresh()
        Reporte.Subreports("Costeo Producto Ruma").SetDatabaseLogon("SA", "123", Servidor_App, BD_App)

        'With Reporte.Subreports(0).Database.Tables(0).LogOnInfo.ConnectionInfo
        '    .ServerName = Servidor_App
        '    .DatabaseName = BD_App
        '    .UserID = "SA"
        '    .Password = "123"
        '    .IntegratedSecurity = True
        'End With

        Reporte.Refresh()
        Me.CRView.ReportSource = Reporte
        CRView.Refresh()

    End Sub
End Class