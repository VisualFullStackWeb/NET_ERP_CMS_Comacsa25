Imports SIP_Entidad
Imports SIP_Negocio
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class Rpt_Suministros_Envio

    Dim ReportesBL As New NGReportes

#Region "Variables"

    Private _NumeroReporte As Integer
    Private _DatosReporte As Object = Nothing
    Private _NombreReporte As String = String.Empty
    Public Tipo As Boolean = Boolean.FalseString
    Private RptCrystal As Object = Nothing

#End Region

#Region "Property"


    Public Property NombreReporte() As String
        Get
            Return _NombreReporte
        End Get
        Set(ByVal value As String)
            _NombreReporte = value
        End Set
    End Property

    Public Property NumeroReporte() As Integer
        Get
            Return _NumeroReporte
        End Get
        Set(ByVal value As Integer)
            _NumeroReporte = value
        End Set
    End Property

    Public Property DatosReporte() As Object
        Get
            Return _DatosReporte
        End Get
        Set(ByVal value As Object)
            _DatosReporte = value
        End Set
    End Property

#End Region

#Region "Eventos"

    Sub Evento_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent, Nothing, Boolean.TrueString)

    End Sub

    Sub Evento_Deactivate(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Deactivate

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Call AdministrarToolBar(MdiParent)

    End Sub

    Sub Evento_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If _DatosReporte IsNot Nothing Then _DatosReporte = Nothing
        If RptCrystal IsNot Nothing Then RptCrystal = Nothing

    End Sub

    Sub Evento_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        If MessageBox.Show(" ¿ Seguro desea Salir del Reporte ?", Mensaje.Comacsa, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            e.Cancel = Boolean.TrueString
        End If

    End Sub

    Sub Evento_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        If sender Is Nothing OrElse e Is Nothing Then
            Return
        End If

        Text &= NombreReporte

        Call Iniciar()

    End Sub

#End Region

#Region "Procedimientos"

    Sub Iniciar()

        Dim ds1 As New DataSet
        Dim Listar As New Crp_AtencionProductos

        ds1 = ReportesBL.ListarProductosAtendidos(gDocumentoSalidaOrden, gDocumentoAtender, Companhia)

        Listar.SetDataSource(ds1.Tables(0))
        ReporteListarProductos.ReportSource = Listar
        ReporteListarProductos.Zoom(1)
    End Sub

#End Region

End Class