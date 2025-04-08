Imports SIP_Entidad
Imports SIP_Reporte
Imports System

Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Windows


Public Class FrmBReporte

#Region "Variables"

    Private IntNumReporte As Integer
    Private _DatosReporte As Object = Nothing
    Private StrTextReporte As String = String.Empty
    Public Tipo As Boolean = Boolean.FalseString
    Private RptCrystal As Object = Nothing

    Private _NumeroSalidaOrden As String = String.Empty
    Private _NumeroPedido As String = String.Empty

    Private _NombreReporteCR As String = String.Empty

    Private _Ls_ParametroCR As New List(Of ETParametro)
#End Region

#Region "Property"

    Public Property Ls_ParametroCR() As List(Of ETParametro)
        Get
            Return _Ls_ParametroCR
        End Get
        Set(ByVal value As List(Of ETParametro))
            _Ls_ParametroCR = value
        End Set
    End Property
    Public Property NombreReporteCR() As String
        Get
            Return _NombreReporteCR
        End Get
        Set(ByVal value As String)
            _NombreReporteCR = value
        End Set
    End Property
    Public Property NumeroSalidaOrden() As String
        Get
            Return _NumeroSalidaOrden
        End Get
        Set(ByVal value As String)
            _NumeroSalidaOrden = value
        End Set
    End Property

    Public Property NumeroPedido() As String
        Get
            Return _NumeroPedido
        End Get
        Set(ByVal value As String)
            _NumeroPedido = value
        End Set
    End Property

    Public Property TextReporte() As String
        Get
            Return StrTextReporte
        End Get
        Set(ByVal value As String)
            StrTextReporte = value
        End Set
    End Property

    Public Property NumReporte() As Integer
        Get
            Return IntNumReporte
        End Get
        Set(ByVal value As Integer)
            IntNumReporte = value
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

        Text &= TextReporte

        If Not (String.IsNullOrEmpty(NombreReporteCR.Trim)) Then
            Dim DT As New DataTable
            DT = DatosReporte
            Call Muestra_Reporte(DT, "", "")
        Else
            Call Iniciar()
        End If


    End Sub

#End Region

#Region "Procedimientos"
#Region "Reportes CR"
    Private Shared LogInfo As CrystalDecisions.Shared.ConnectionInfo

    Public Shared Sub Conectar()

        LogInfo = New CrystalDecisions.Shared.ConnectionInfo

        LogInfo.ServerName = Servidor_App

        LogInfo.DatabaseName = BD_App

        LogInfo.IntegratedSecurity = True


    End Sub

    Private Sub LogonRpt(ByRef reporte As ReportDocument)

        Dim crtableLogoninfos As New TableLogOnInfos

        Dim crtableLogoninfo As New TableLogOnInfo

        Dim crConnectionInfo As New ConnectionInfo

        Dim CrTables As Tables

        Dim CrTable As Table

        Call Conectar()
        crConnectionInfo = LogInfo

        CrTables = reporte.Database.Tables

        For Each CrTable In CrTables

            crtableLogoninfo = CrTable.LogOnInfo

            crtableLogoninfo.ConnectionInfo = crConnectionInfo

            CrTable.ApplyLogOnInfo(crtableLogoninfo)

        Next

    End Sub




#End Region
    Public Sub Muestra_Reporte(ByVal myDatos As DataTable, ByVal STRnombreTabla As String, ByVal STRfiltro As String)
        Try

            Dim myReporte As New ReportDocument
            'Cargo el reporte segun ruta
            'myReporte.PrintOptions.PaperSize = PaperSize.PaperFanfoldUS
            'myReporte.PrintOptions.PaperOrientation = PaperOrientation.Portrait

            'Leo los parametros
            If Ls_ParametroCR.Count > 0 Then
                CrvInforme.ParameterFieldInfo = Genera_Parametros(Ls_ParametroCR)
            End If

            myReporte.Load(NombreReporteCR, OpenReportMethod.OpenReportByDefault)

            Call LogonRpt(myReporte)

           
            'CrvInforme.SelectionFormula = STRfiltro
            myReporte.SetDataSource(myDatos)

            'Levanto el formulario del reporte
            CrvInforme.ReportSource = myReporte
            CrvInforme.ShowGroupTreeButton = True


        Catch ex As Exception
            Throw
        End Try

    End Sub


    Sub Iniciar()

        RptCrystal = New Object
        Reporte.Informe = New RptInforme(Servidor_App, BD_App)
        Reporte.Informe.ReporteCR = Me.NombreReporteCR
        If Not Tipo Then
            RptCrystal = Reporte.Informe.Cargar_Proceso_Crystal(NumReporte, DatosReporte)
        Else
            RptCrystal = Reporte.Informe.Cargar_Proceso_Consulta(NumReporte, DatosReporte)
        End If

        If RptCrystal Is Nothing Then Return

        If Not (String.IsNullOrEmpty(NombreReporteCR.Trim)) Then
            If Ls_ParametroCR.Count > 0 Then
                CrvInforme.ParameterFieldInfo = Genera_Parametros(Ls_ParametroCR)
            End If
        End If

        CrvInforme.ReportSource = RptCrystal
        CrvInforme.Zoom(1)

    End Sub

    Private Function Genera_Parametros(ByVal Ls_Parametro As List(Of ETParametro)) As ParameterFields

        Dim parametros As New ParameterFields

        Try
            For Each xRow As ETParametro In Ls_Parametro
                Dim Parametro As New ParameterField
                Dim dVal As New ParameterDiscreteValue
                Parametro.ParameterFieldName = xRow.Parametro
                dVal.Value = xRow.Valor
                Parametro.CurrentValues.Add(dVal)
                parametros.Add(Parametro)

            Next
            Return (parametros)
        Catch ex As Exception
            Throw
        End Try
    End Function

#End Region

End Class