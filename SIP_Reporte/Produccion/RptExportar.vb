Imports SIP_Negocio
Imports SIP_Entidad
Imports System
Imports System.Collections
Imports System.Configuration
Imports CrystalDecisions
Imports CrystalDecisions.CrystalReports
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.Shared.ExportFormatType
Imports CrystalDecisions.Shared.ExportDestinationType
Imports CrystalDecisions.Shared.OpenReportMethod

Public Class RptExportar

    Inherits RptInforme

    Private CrReporte As Object = Nothing
    Private EODocumento As ExportOptions = Nothing
    Private DFDODestino As DiskFileDestinationOptions = Nothing
    Private RutaDocumento As String = String.Empty

    Enum TipoDoc
        Word = 1
        Excel = 2
        Pdf = 3
    End Enum

    Public Sub Cargar_Consulta(ByVal I As Int16, ByVal Source As Object, ByVal Rpt As TipoDoc, ByVal Nombre As String, ByVal Carpeta As Short)

        CrReporte = New Object

        CrReporte = Cargar_Proceso_Consulta(I, Source)

        If CrReporte Is Nothing Then Return

        Call CrearDirectorio()

        RutaDocumento = CarpetaDestino(Carpeta)

        EODocumento = New ExportOptions
        DFDODestino = New DiskFileDestinationOptions

        If Rpt = TipoDoc.Word Then
            EODocumento.ExportFormatType = WordForWindows
        ElseIf Rpt = TipoDoc.Excel Then
            EODocumento.ExportFormatType = Excel
        Else
            EODocumento.ExportFormatType = PortableDocFormat
        End If

        EODocumento.ExportDestinationType = DiskFile
        DFDODestino.DiskFileName = RutaDirectory & RutaDocumento & Nombre & ExtensionArchivo(Rpt)

        EODocumento.ExportDestinationOptions = DFDODestino.Clone
        CrReporte.Export(EODocumento)

        System.Diagnostics.Process.Start(RutaDirectory & RutaDocumento & Nombre & ExtensionArchivo(Rpt))

    End Sub

    Public Sub Cargar_Crystal(ByVal Source As Object, ByVal Rpt As TipoDoc, ByVal Nombre As String, ByVal Carpeta As Short)

        CrReporte = New Object

        CrReporte = Source

        If CrReporte Is Nothing Then Return

        Call CrearDirectorio()

        RutaDocumento = CarpetaDestino(Carpeta)

        EODocumento = New ExportOptions
        DFDODestino = New DiskFileDestinationOptions

        If Rpt = TipoDoc.Word Then
            EODocumento.ExportFormatType = WordForWindows
        ElseIf Rpt = TipoDoc.Excel Then
            EODocumento.ExportFormatType = Excel
        Else
            EODocumento.ExportFormatType = PortableDocFormat
        End If

        EODocumento.ExportDestinationType = DiskFile
        DFDODestino.DiskFileName = RutaDirectory & RutaDocumento & Nombre & ExtensionArchivo(Rpt)

        EODocumento.ExportDestinationOptions = DFDODestino.Clone
        CrReporte.Export(EODocumento)

        System.Diagnostics.Process.Start(RutaDirectory & RutaDocumento & Nombre & ExtensionArchivo(Rpt))

    End Sub

    Private Function ExtensionArchivo(ByVal Rpt As TipoDoc) As String

        Dim lResult As String = String.Empty

        Select Case Rpt
            Case TipoDoc.Word : lResult = ".doc"
            Case TipoDoc.Excel : lResult = ".xls"
            Case TipoDoc.Pdf : lResult = ".pdf"
        End Select

        Return lResult

    End Function

    Private Function CarpetaDestino(ByVal Carpeta As VarReporte) As String

        Dim lResult As String = String.Empty

        If Carpeta = VarReporte.Exportacion Then
            lResult = RutaProformas
        ElseIf Carpeta = VarReporte.Orden Then
            lResult = RutaOrden
        ElseIf Carpeta = VarReporte.Requerimiento Then
            lResult = RutaRequerimientos
        End If

        Return lResult

    End Function

End Class
