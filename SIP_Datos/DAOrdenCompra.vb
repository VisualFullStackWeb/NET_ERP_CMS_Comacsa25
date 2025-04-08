Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception

Public Class DAOrdenCompra

    Inherits ETObjecto

    '   *****   usp_RAL_OC_Aprobacion           ****

#Region "Listar Cabecera Orden de Compra"
    Public Function ListarCabOrdenCompra(ByVal OC As ETOrdenCompra) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OC_Aprobacion)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, OC.Cod_Cia)
            db.AddInParameter(cmd, "Aprobada", DbType.String, OC.Aprobada)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, OC.Fec_Crea)
            db.AddInParameter(cmd, "FechaFin", DbType.DateTime, OC.Fec_Entrega)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarCabOrdenCompra = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_OC_Aprobacion_Usuario   *****

#Region "Listar Cabecera Orden de Compra x Usuario"
    Public Function ListarCabOrdenCompraUsuario(ByVal OC As ETOrdenCompra) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OC_Aprobacion_Usuario)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, OC.Cod_Cia)
            db.AddInParameter(cmd, "Aprobada", DbType.String, OC.Aprobada)
            db.AddInParameter(cmd, "Usuario", DbType.String, OC.User_Crea)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, OC.Fec_Crea)
            db.AddInParameter(cmd, "FechaFin", DbType.DateTime, OC.Fec_Entrega)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarCabOrdenCompraUsuario = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_DETALLE_OC                      *****

#Region "Listar Detalle OC"
    Public Function ListarDetalleOC(ByVal OC As ETOrdenCompra) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Detalle_OC)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, OC.Cod_Cia)
            db.AddInParameter(cmd, "NroOC", DbType.String, OC.Nro_OC)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDetalleOC = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_MejorPrecio_PorRangoFecha_OC    ***** 

#Region "Listar Top 5 Mejores Proveedores"
    Public Function ListarTopMejores(ByVal Producto As ETProducto) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MejorPrecio)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Producto.cod_cia)
            db.AddInParameter(cmd, "Cod_Producto", DbType.String, Producto.CodProducto)
            db.AddInParameter(cmd, "Unidad", DbType.String, Producto.unidad)
            db.AddInParameter(cmd, "Moneda", DbType.String, Producto.moneda)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarTopMejores = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RALL_OrdenCotizacionLogistica   ****   

#Region "Articulos Comparados"
    Public Function ArticulosComparados(ByVal OC As ETOrdenCompra, ByVal Tipo As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OrdenCotizacionLogistica)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, OC.Cod_Cia)
            db.AddInParameter(cmd, "Nro_OC", DbType.String, OC.Nro_OC)
            db.AddInParameter(cmd, "Cod_Prod", DbType.String, OC.Cod_Prod)
            db.AddInParameter(cmd, "Tipo", DbType.String, Tipo)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ArticulosComparados = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

    '   *****   usp_RAL_DocumentosReferencia        *****
    '   Opcion  :   VA1     =>  Validar Documentos de Referencia por Proveedor
    '   Opcion  :   VA2     =>  

#Region "Documentos de Referencia"

    Public Function DocumentosReferencia(ByVal Guia As ETGuia, ByVal Opcion As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DocumentosReferencia)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Guia.Cod_Cia)
            db.AddInParameter(cmd, "Cod_Cliente", DbType.String, Guia.Cod_Cli)
            db.AddInParameter(cmd, "TipoDocRef", DbType.String, Guia.TipDocRef)
            db.AddInParameter(cmd, "NumDocRef", DbType.String, Guia.NumDocRef)
            db.AddInParameter(cmd, "Tipo_Mov", DbType.String, Guia.Tipo_Mov)
            db.AddInParameter(cmd, "Tipo_Doc", DbType.String, Guia.Tipo_Doc)
            db.AddInParameter(cmd, "NumeroDocumento", DbType.String, Guia.NumDoc)
            db.AddInParameter(cmd, "Opcion", DbType.String, Opcion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            DocumentosReferencia = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        'Dim dt As New DataTable
        'Using cnx As New SqlConnection(ConnectionString.ConnectionString)
        '    Using cmd As New SqlCommand("usp_RAL_DocumentosReferencia", cnx)
        '        With cmd
        '            .Parameters.AddWithValue("@Cod_Cia", Guia.Cod_Cia)
        '            .Parameters.AddWithValue("@Cod_Cliente", Guia.Cod_Cli)
        '            .Parameters.AddWithValue("@TipoDocRef", Guia.TipDocRef)
        '            .Parameters.AddWithValue("@NumDocRef", Guia.NumDocRef)
        '            .Parameters.AddWithValue("@Opcion", "VA1")
        '            .CommandType = CommandType.StoredProcedure
        '        End With
        '        Try
        '            cnx.Open()
        '            Dim da As New SqlDataAdapter(cmd)
        '            da.Fill(dt)
        '            cnx.Close()
        '        Catch ex As Exception
        '            Throw
        '        End Try
        '    End Using
        'End Using
        'Return dt
    End Function


#End Region

End Class
