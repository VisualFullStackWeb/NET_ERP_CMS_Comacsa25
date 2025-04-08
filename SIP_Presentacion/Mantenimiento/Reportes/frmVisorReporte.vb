Imports SIP_Entidad
Imports SIP_Negocio
Imports SIP_Reporte

Public Class frmVisorReporte
#Region "Declarar Variables"
    Public Ls_Permisos As New List(Of Integer)
    Private _OrdenTrabajo As Long = 0
    Private _Presupuesto As Long = 0
    Private _Status As String = String.Empty
    Private Ruta As String = String.Empty
    Private Reporte As New CrystalDecisions.CrystalReports.Engine.ReportDocument
#End Region

#Region "Propiedades Publicas"
    Public Property OrdenTrabajo() As Long
        Get
            Return _OrdenTrabajo
        End Get
        Set(ByVal value As Long)
            _OrdenTrabajo = value
        End Set
    End Property

    Public Property Presupuesto() As Long
        Get
            Return _Presupuesto
        End Get
        Set(ByVal value As Long)
            _Presupuesto = value
        End Set
    End Property

    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property
#End Region
    Private Sub frmVisorReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Text = ".::: Presupuesto vs Orden de Trabajo :::."
        Dim dsRep As DataSet
        Dim dsSubRep1 As DataSet
        Dim dsSubRep2 As DataSet
        Dim dsSubRep3 As DataSet
        Dim dsSubRep4 As DataSet
        Dim dsSubRep5 As DataSet
        Dim dsSubRep6 As DataSet

        Entidad.OrdenTrabajo.OrdenTrabajo = Me.OrdenTrabajo
        Entidad.OrdenTrabajo.Presupuesto = Me.Presupuesto
        Entidad.OrdenTrabajo.Status = Me.Status
        Entidad.OrdenTrabajo.Tipo = 0
        dsRep = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_AnalisisCostos(Entidad.OrdenTrabajo)
        Ruta = My.Application.Info.DirectoryPath
        Ruta = Ruta + "\Reportes\CRReportePresupuesto_vs_OT.rpt"
        Reporte.Load(Ruta, CrystalDecisions.Shared.OpenReportMethod.OpenReportByDefault)
        Entidad.OrdenTrabajo.Tipo = 1
        dsSubRep1 = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_AnalisisCostos(Entidad.OrdenTrabajo)
        Entidad.OrdenTrabajo.Tipo = 2
        dsSubRep2 = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_AnalisisCostos(Entidad.OrdenTrabajo)
        Entidad.OrdenTrabajo.Tipo = 3
        dsSubRep3 = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_AnalisisCostos(Entidad.OrdenTrabajo)
        Entidad.OrdenTrabajo.Tipo = 4
        dsSubRep4 = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_AnalisisCostos(Entidad.OrdenTrabajo)
        Entidad.OrdenTrabajo.Tipo = 5
        dsSubRep5 = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_AnalisisCostos(Entidad.OrdenTrabajo)
        Entidad.OrdenTrabajo.Tipo = 6
        dsSubRep6 = Negocio.Orden_Trabajo.Consultar_OrdenTrabajo_AnalisisCostos(Entidad.OrdenTrabajo)

        Reporte.Subreports(0).SetDataSource(dsSubRep1.Tables(0))
        Reporte.Subreports(4).SetDataSource(dsSubRep2.Tables(0))
        Reporte.Subreports(2).SetDataSource(dsSubRep3.Tables(0))
        Reporte.Subreports(3).SetDataSource(dsSubRep4.Tables(0))
        Reporte.Subreports(5).SetDataSource(dsSubRep5.Tables(0))
        Reporte.Subreports(1).SetDataSource(dsSubRep6.Tables(0))
        Reporte.SetDataSource(dsRep.Tables(0))
        Reporte.Refresh()
        Me.CRView.ReportSource = Reporte
        CRView.Refresh()

    End Sub
End Class