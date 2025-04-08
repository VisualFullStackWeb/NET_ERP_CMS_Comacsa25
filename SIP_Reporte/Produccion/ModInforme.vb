Imports System.Configuration
Imports SIP_Entidad
Imports SIP_Negocio
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Module ModInforme

    Public Servidor_App As String = String.Empty
    Public BD_App As String = String.Empty
    Public RutaDirectory As String = "C:\SIP_Archivos\"
    Public RutaRequerimientos As String = "Requerimientos\"
    Public RutaProformas As String = "Proformas\"
    Public RutaOrden As String = "OrdenProduccion\"

    Public Enum VarReporte
        Orden = 1
        Requerimiento = 2
        Exportacion = 3
        ProductoxRuma = 4
        Formula = 5
        ProductoxUnidad = 6
        RequerimientoCompra = 7
        CosteoProduccionxMolino = 8
        CosteoProduccionxProducto = 9
        ProductoxMineral = 10
        TrazabilidadProforma = 11
        DocumentoCrystal = 12
    End Enum

    Public Structure StrucCrystal
        Event z()
        Public Shared RxOrden As RptOrden
        Public Shared RxRequerimiento As RptRequerimiento
        Public Shared RxCuadroExportacion As RptCuadroExportacion1
        Public Shared RxProductoxRuma As RptProductoxRuma
        Public Shared RxFormula As RptFormula
        Public Shared RxProductoxUnidad As RptProductoxUnidad
        Public Shared RxProductoxMineral As RptProductoxRumaxMineral
        Public Shared RxTrazabilidadProforma As RptTrazabilidadProforma
        Public Shared RxDocumentoCrystal As ReportDocument



    End Structure



    Public Structure Entidad
        Event z()
        Public Shared Costo As ETCosto
        Public Shared Mineral As ETMineral
        Public Shared Ruma As ETRuma
        Public Shared Requerimiento As ETRequerimiento
        Public Shared Producto As ETProducto
        Public Shared Usuario As ETUsuario
        Public Shared Activo As ETActivo
        Public Shared Objecto As ETObjecto
        Public Shared Personal As ETPersonal
        Public Shared Proforma As ETProforma
        Public Shared Suministro As ETSuministro
        Public Shared Orden As ETOrden
        Public Shared Cliente As ETCliente
        Public Shared Almacen As ETAlmacen
        Public Shared MyLista As ETMyLista
    End Structure

    Public Structure Negocio
        Event z()
        Public Shared Maestro As NGMaestro
        Public Shared Cliente As NGCliente
        Public Shared Costo As NGCosto
        Public Shared Mineral As NGMineral
        Public Shared Ruma As NGRuma
        Public Shared Reporte As NGReporte
        Public Shared Orden As NGOrden
        Public Shared Producto As NGProducto
        Public Shared Usuario As NGUsuario
        Public Shared Activo As NGActivo
        Public Shared Suministro As NGSuministro
        Public Shared Requerimiento As NGRequerimiento
        Public Shared Personal As NGPersonal
        Public Shared Almacen As NGAlmacen
    End Structure

    Public Sub CrearDirectorio()

        If Not IO.File.Exists(RutaDirectory) Then
            Directory.CreateDirectory(RutaDirectory)
        End If

        If Not IO.File.Exists(RutaDirectory & RutaRequerimientos) Then
            Directory.CreateDirectory(RutaDirectory & RutaRequerimientos)
        End If

        If Not IO.File.Exists(RutaDirectory & RutaOrden) Then
            Directory.CreateDirectory(RutaDirectory & RutaOrden)
        End If

        If Not IO.File.Exists(RutaDirectory & RutaProformas) Then
            Directory.CreateDirectory(RutaDirectory & RutaProformas)
        End If

    End Sub

End Module
