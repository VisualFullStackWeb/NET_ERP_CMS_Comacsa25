Imports System.Security.Cryptography
Imports System.Runtime.Serialization.Formatters.Binary

Module VariablesPublicas
    Public cnx_sispedal As String

    Public gAlmacen As String
    Public gDocumentoAtender As String
    Public gDocumentoSalidaOrden As String
    Public gRequerimiento As String
    Public GUsuarioRecojo As String
    Public GCodigoUsuarioRecojo As String
    Public gArea As String
    Public GLinea As String
    Public gEmpleo As String
    Public GCantera As String
    Public gSistema As String = "20"
    Public GFechaInicio As DateTime = Date.MinValue
    Public GFechaFin As DateTime = Date.MaxValue
    Public GOpcion As Integer
    Public nroSolicitud As String = String.Empty
    'Datos User
    Public gAdmin As String
    Public gCodigoUsuario As String
    Public gAreaUsuario As String
    Public gAreaEmpleado As String = ""
    Public gAreaMantto As Boolean = False

    Public Numero_MovimientoAlmacen As String

    '   *****   ESTRUCTURA GUIA REMISION   *****
    Public GR_CodigoCantera As String = ""
    Public GR_Cantera As String = ""
    Public GR_Direccion As String = ""
    Public GR_CodigoUbicacion_I As String = ""
    Public GR_Direccion_I As String = ""
    Public GR_CodigoUbicacion As String = ""
    Public GR_UbicacionGeografica As String = ""
    Public GR_CodigoRazonSocialDestinatario As String = ""
    Public GR_RazonSocialDestinatario As String = ""
    Public GR_RucDestinatario As String = ""
    Public GR_DniDestinatario As String = ""
    Public GR_Enviado As String = ""

    Public GR_CodigoRazonSocialTransportista As String = ""
    Public GR_RazonSocialTransportista As String = ""
    Public GR_RucTransportista As String = ""
    Public GR_Marca As String = ""
    Public GR_Placa As String = ""
    Public GR_CertificadoInscripcion As String = ""
    Public GR_Licencia As String = ""
    Public GR_NombreChofer As String = ""

    '   *****   PRODUCTOS   *****  
    Public Productos_Codigo As String = ""
    Public Productos_Descripcion As String = ""
    Public Productos_TipoProducto As String = ""
    Public Productos_UM As String = ""
    Public Productos_UM_Compra As String = ""
    Public Productos_Stock As Decimal = 0

    Public xFormulario As String = ""

    '   ENVIO A CANTERAS    
    Public Listado_Envio_Cantera As New DataTable

End Module
