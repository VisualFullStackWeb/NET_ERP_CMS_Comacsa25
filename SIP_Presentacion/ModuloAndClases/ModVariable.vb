Imports System.Configuration
Imports SIP_Entidad
Module ModVariable
    Public Const ValorFechaMinima As String = "01-01-1900"

    Public DateFechaMinima As Date = CDate(ValorFechaMinima)

    Public StrDominio As String = ConfigurationManager.AppSettings.Get("Dominio")

    Public User_Sistema As String = String.Empty
    Public Contrasenha_Sistema As String = String.Empty
    Public Placod_User As String = String.Empty
    Public Nombre_User As String = String.Empty
    Public Servidor_App As String = String.Empty
    Public BD_App As String = String.Empty

    Public USERINI As String = ConfigurationManager.AppSettings.Get("UserBD")
    Public PASSINI As String = ConfigurationManager.AppSettings.Get("PassBD")
    Public BDINI As String = ConfigurationManager.AppSettings.Get("BD")
    Public DATASOURCE As String = ConfigurationManager.AppSettings.Get("DATASOURCE")

    Public PASSUSER As String = ConfigurationManager.AppSettings.Get("PassUser")

    Public Terminal As String = ConfigurationManager.AppSettings.Get("Terminal")
    Public CarpetaArchivo As String = ConfigurationManager.AppSettings.Get("RutaArchivo")
    Public Companhia As String = ConfigurationManager.AppSettings.Get("Companhia")
    Public strTipoProd As String = ConfigurationManager.AppSettings.Get("TipoProducto")
    Public strAlmacen As String = ConfigurationManager.AppSettings.Get("Almacen")
    Public Sistema As String = ConfigurationManager.AppSettings.Get("Sistema")
    Public RutaReporteERP As String = ConfigurationManager.AppSettings.Get("RutaReportes")
    Public RutaReporteERP_MP As String = ConfigurationManager.AppSettings.Get("RutaReportes_MP")
    Public RutaReporteERP_PP As String = ConfigurationManager.AppSettings.Get("RutaReportes_PP")
    Public RutaReportes_UNCAEM As String = ConfigurationManager.AppSettings.Get("RutaReportes_UNCAEM")
    Public codTrabajadorInicio As String = String.Empty
    Public nomTrabajadorInicio As String = String.Empty
    Public StrTema As String = ConfigurationManager.AppSettings.Get("Tema")
    Public StrEstilo As String = ConfigurationManager.AppSettings.Get("Estilo")

    Public Correo_MinasTo As String() = {"minas@comacsa.com.pe", "otros@comacsa.com.pe"}
    Public Correo_MinasCC As String() = {"CC@comacsa.com.pe", "otrosCC@comacsa.com.pe"}
    Public Correo_Asunto As String = String.Empty
    Public Correo_Adjunto As String = String.Empty
    Public Correo_Cuerpo As String = String.Empty
    Public FechaMinimaBD As Date = CDate(ValorFechaMinima)

    Public StrRutaTemas As String = "\\Server03\siscomacsa$\SistProduccion\StyleLibraries\"
    Public StrRutaProductos As String = "\\Server03\siscomacsa$\Fotos_Productos\"

    Public msgComacsa As String = "COMACSA"

    Public codConcepto As String = String.Empty
    Public Concepto As String = String.Empty
    Public codCantera As String = String.Empty
    Public Cantera As String = String.Empty
    Public codProd As String = String.Empty
    Public Producto As String = String.Empty
    Public codContratista As String = String.Empty
    Public codCliente As String = String.Empty
    Public orden As String = String.Empty
    Public Contratista As String = String.Empty
    Public Cliente As String = String.Empty
    Public Region As String = String.Empty
    Public userLogin As String = String.Empty
    Public codMotivodetalle As String = String.Empty
    Public Motivodetalle As String = String.Empty
    Public codTrabajador As String = String.Empty
    Public Ruc As String = String.Empty
    Public nomTrabajador As String = String.Empty
    Public ctatrabajador As String = String.Empty
    Public bcotrabajador As String = String.Empty
    Public ctatrabajadorini As String = String.Empty
    Public bcotrabajadorini As String = String.Empty
    'HVilela 19/02/2025 - Tarjeta de Consumo ------------------
    Public numeroTarjetaConsumo As String = String.Empty
    Public tipoTarjetaConsumo As String = String.Empty
    Public bancoTarjetaConsumo As String = String.Empty
    Public saliniTarjetaConsumo As Int32 = 0
    Public idTarjetaConsumo As Int32 = 0
    Public idTipoTarjetaConsumo As Int32 = 0
    Public nroTarjeta As String = String.Empty
    Public totalSolicitud As Decimal = 0.0
    '----------------------------------------------------------
    Public codTipoDoc As String = String.Empty
    Public combustible As String = String.Empty
    Public TipoDoc As String = String.Empty
    Public codCuenta As String = String.Empty
    Public Cuenta As String = String.Empty
    Public codArea As String = String.Empty
    Public Area As String = String.Empty
    Public codProducto As String = String.Empty
    Public codAuxiliar As String = String.Empty
    Public Auxiliar As String = String.Empty
    Public flgcompra As Int32 = 0
    Public Ls_DocAsociado As List(Of ETEntregas) = Nothing
    Public Ls_DocAsociadoEliminado As List(Of ETEntregas) = Nothing
    Public Ls_DocMovilidad As List(Of ETEntregas) = Nothing
    Public Ls_DocMovilidadEliminado As List(Of ETEntregas) = Nothing
    Public Ls_DocnoRegistrado As List(Of ETEntregas) = Nothing
    Public Ls_DocCombustible As List(Of ETEntregas) = Nothing
    Public Ls_DocCombustibleEliminado As List(Of ETEntregas) = Nothing

    Public Ls_DetalleRecibo As List(Of ETEntregas) = Nothing
    Public Ls_DetalleReciboEliminado As List(Of ETEntregas) = Nothing

    Public Saldo_LC_T1 = 0.0  'Para indicar el saldo de T&E
    Public Saldo_LC_T2 = 0.0  'Para indicar el saldo P-Card

    REM Function selector OK
    'Dim max As Decimal = List.Max(Function(Rpt As ETActivo) Rpt.Rendimiento)
    'Dim min As Decimal = List.Min(Function(Rpt As ETActivo) Rpt.Rendimiento)
    'Dim Sum As Decimal = List.Sum(Function(Rpt As ETActivo) Rpt.Rendimiento)
    'Dim Prod As Decimal = List.Average(Function(Rpt As ETActivo) Rpt.Rendimiento)
    'ET_Producto.Sort(AddressOf Negocio.Producto.Ordenar_Descripcion_Asc)
    'ListProducto = ListProducto.OrderBy(Function(Rpt As ETProducto) Rpt.CodProducto).ToList

End Module
