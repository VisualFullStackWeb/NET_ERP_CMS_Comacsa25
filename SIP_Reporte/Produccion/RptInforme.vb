Imports SIP_Negocio
Imports SIP_Entidad
Imports System
Imports System.IO
Imports System.Collections
Imports System.Configuration
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class RptInforme

#Region "Variables"
    Private _ReporteCR As String = String.Empty
    Private RptDocument As ReportDocument
    Private strRutaArchivo As String = String.Empty
    Private ObjReporte As Object
    Private oConexInfo As ConnectionInfo
    Private oListaTablas As Tables
    Private oTabla As Engine.Table
    Private oTablaConexInfo As TableLogOnInfo
    Private pvValoresParametros As ParameterValues
    Private pvValoresParametros1 As ParameterValues
    Private pvValoresParametros2 As ParameterValues
    Private pvValoresParametros3 As ParameterValues
    Private pParametro1 As ParameterDiscreteValue
    Private pParametro2 As ParameterDiscreteValue
    Private pParametro3 As ParameterDiscreteValue
    Private pParametro4 As ParameterDiscreteValue

#End Region

    Public Property ReporteCR() As String
        Get
            Return _ReporteCR
        End Get
        Set(ByVal value As String)
            _ReporteCR = value
        End Set
    End Property
    Sub New(Optional ByVal Serv As String = "", Optional ByVal BD As String = "")

        Servidor_App = Serv
        BD_App = BD

    End Sub

#Region "Funciones"

    Private Function ConectarReporte(ByVal I As Int16) As Object

        Dim lResult As Object = Nothing
        oConexInfo = New ConnectionInfo()


        oConexInfo.ServerName = Servidor_App
        oConexInfo.DatabaseName = BD_App
        oConexInfo.IntegratedSecurity = Boolean.TrueString

        'MsgBox(oConexInfo.ServerName)
        'MsgBox(oConexInfo.DatabaseName)

        lResult = New Object
        lResult = PathReporte(I, ReporteCR)

        Try
            oListaTablas = lResult.Database.Tables
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        For Each Me.oTabla In oListaTablas
            oTablaConexInfo = oTabla.LogOnInfo
            oTablaConexInfo.ConnectionInfo = oConexInfo
            oTabla.ApplyLogOnInfo(oTablaConexInfo)

        Next

        Return lResult

    End Function

    Private Function PathReporte(ByVal Tipo As Int16, Optional ByVal NombreReporte As String = "") As Object

        Dim lResult As Object = Nothing
        lResult = New Object

        If String.IsNullOrEmpty(NombreReporte.Trim) Then
            Select Case Tipo
                Case VarReporte.Orden
                    StrucCrystal.RxOrden = New RptOrden
                    lResult = StrucCrystal.RxOrden
                Case VarReporte.Requerimiento
                    StrucCrystal.RxRequerimiento = New RptRequerimiento
                    lResult = StrucCrystal.RxRequerimiento
                Case VarReporte.Exportacion
                    StrucCrystal.RxCuadroExportacion = New RptCuadroExportacion1
                    lResult = StrucCrystal.RxCuadroExportacion
                Case VarReporte.ProductoxRuma
                    StrucCrystal.RxProductoxRuma = New RptProductoxRuma
                    lResult = StrucCrystal.RxProductoxRuma
                Case VarReporte.Formula
                    StrucCrystal.RxFormula = New RptFormula
                    lResult = StrucCrystal.RxFormula
                Case VarReporte.ProductoxUnidad
                    StrucCrystal.RxProductoxUnidad = New RptProductoxUnidad
                    lResult = StrucCrystal.RxProductoxUnidad
                Case VarReporte.ProductoxMineral
                    StrucCrystal.RxProductoxMineral = New RptProductoxRumaxMineral
                    lResult = StrucCrystal.RxProductoxMineral
                Case VarReporte.TrazabilidadProforma
                    StrucCrystal.RxTrazabilidadProforma = New RptTrazabilidadProforma
                    lResult = StrucCrystal.RxTrazabilidadProforma
                Case Else

            End Select

        Else
            StrucCrystal.RxDocumentoCrystal = New ReportDocument
            StrucCrystal.RxDocumentoCrystal.Load(NombreReporte, OpenReportMethod.OpenReportByDefault)
            lResult = StrucCrystal.RxDocumentoCrystal
        End If

        Return lResult

    End Function

    Private Function ParameterReporte(ByVal Tipo As Int16, ByVal Reporte As Object, ByVal Parametros As Object) As Object

        ParameterReporte = New Object
        pvValoresParametros = New ParameterValues
        pvValoresParametros1 = New ParameterValues
        pvValoresParametros2 = New ParameterValues
        pvValoresParametros3 = New ParameterValues

        Select Case Tipo
            Case VarReporte.Orden

                Entidad.Orden = New ETOrden
                pParametro1 = New ParameterDiscreteValue

                Entidad.Orden = Parametros
                pParametro1.Value = Entidad.Orden.NroDocumento

                pvValoresParametros.Add(pParametro1)

                Reporte.DataDefinition.ParameterFields("@NroDocumento").ApplyCurrentValues(pvValoresParametros)

            Case VarReporte.Exportacion

                Entidad.Proforma = New ETProforma
                pParametro1 = New ParameterDiscreteValue

                Entidad.Proforma = Parametros
                pParametro1.Value = Entidad.Proforma.NumPedido

                pvValoresParametros.Add(pParametro1)

                Reporte.DataDefinition.ParameterFields("@NumPedido").ApplyCurrentValues(pvValoresParametros)

            Case VarReporte.CosteoProduccionxMolino, VarReporte.CosteoProduccionxProducto

                Dim ObjOrden As ETOrden
                ObjOrden = New ETOrden
                ObjOrden = Parametros

                pParametro1 = New ParameterDiscreteValue
                pParametro1.Value = ObjOrden.Cod_Cia
                pvValoresParametros.Add(pParametro1)

                pParametro2 = New ParameterDiscreteValue
                pParametro2.Value = ObjOrden.FechaInicio
                pvValoresParametros1.Add(pParametro2)

                pParametro3 = New ParameterDiscreteValue
                pParametro3.Value = ObjOrden.FechaTerminacion
                pvValoresParametros2.Add(pParametro3)

                pParametro4 = New ParameterDiscreteValue
                pParametro4.Value = ObjOrden.CodProducto
                pvValoresParametros3.Add(pParametro4)


                Reporte.DataDefinition.ParameterFields("@codcia").ApplyCurrentValues(pvValoresParametros)
                Reporte.DataDefinition.ParameterFields("@Producto").ApplyCurrentValues(pvValoresParametros3)
                Reporte.DataDefinition.ParameterFields("@fecini").ApplyCurrentValues(pvValoresParametros1)
                Reporte.DataDefinition.ParameterFields("@fecfin").ApplyCurrentValues(pvValoresParametros2)

            Case VarReporte.ProductoxMineral

                Dim ObjOrden As ETOrden
                ObjOrden = New ETOrden
                ObjOrden = Parametros

                pParametro1 = New ParameterDiscreteValue
                pParametro1.Value = ObjOrden.Cod_Cia
                pvValoresParametros.Add(pParametro1)

                pParametro2 = New ParameterDiscreteValue
                pParametro2.Value = ObjOrden.CodProducto
                pvValoresParametros1.Add(pParametro2)

                Reporte.DataDefinition.ParameterFields("@Companhia").ApplyCurrentValues(pvValoresParametros)
                Reporte.DataDefinition.ParameterFields("@CodProducto").ApplyCurrentValues(pvValoresParametros1)

            Case VarReporte.TrazabilidadProforma

                Dim ObjOrden As ETOrden
                ObjOrden = New ETOrden
                ObjOrden = Parametros

                pParametro1 = New ParameterDiscreteValue
                pParametro1.Value = ObjOrden.Cod_Cia
                pvValoresParametros.Add(pParametro1)

                pParametro2 = New ParameterDiscreteValue
                pParametro2.Value = ObjOrden.NroDocumento
                pvValoresParametros1.Add(pParametro2)

                Reporte.DataDefinition.ParameterFields("@Cod_Cia").ApplyCurrentValues(pvValoresParametros)
                Reporte.DataDefinition.ParameterFields("@Proforma").ApplyCurrentValues(pvValoresParametros1)

            Case VarReporte.DocumentoCrystal

                Dim Ls_Parametro As New List(Of ETParametro)
                Ls_Parametro = Parametros

                Try
                    For Each xRow As ETParametro In Ls_Parametro
                        Dim pValorParametroCR As New ParameterValues
                        Dim dVal As New ParameterDiscreteValue
                        dVal.Value = xRow.Valor
                        pValorParametroCR.Add(dVal)
                        Reporte.DataDefinition.ParameterFields(xRow.Parametro).ApplyCurrentValues(pValorParametroCR)
                    Next
                    'Return (Parametros)
                Catch ex As Exception
                    Throw
                End Try

            Case Else

        End Select

        ParameterReporte = Reporte

        Return ParameterReporte

    End Function

    Public Function Cargar_Proceso_Crystal(ByVal I As Int16, Optional ByVal Parametros As Object = Nothing) As Object

        Dim lResult As Object = Nothing

        lResult = New Object
        lResult = ConectarReporte(I)
        lResult = ParameterReporte(I, lResult, Parametros)

        Return lResult

    End Function

    Public Function Cargar_Proceso_Consulta(ByVal I As Int16, ByVal Source As Object) As Object

        Dim lResult As Object = Nothing
        If Source Is Nothing Then
            Return lResult
        End If

        lResult = New Object

        lResult = PathReporte(I, ReporteCR)

        lResult.SetDataSource(Source)

        Return lResult

    End Function

#End Region



End Class
