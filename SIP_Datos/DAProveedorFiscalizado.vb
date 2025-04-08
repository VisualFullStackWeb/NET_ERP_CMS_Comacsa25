Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAProveedorFiscalizado

    Public Sub Insertar_ProveedorFiscalizado(ByVal C As ETProveedorFiscalizado)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Insertar_ProveedorFiscalizado)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@Cod_Prov", DbType.String, C.Cod_Prov)
                db.AddInParameter(cmd, "@FechIniVig", DbType.DateTime, C.FechIniVig)
                db.AddInParameter(cmd, "@FechFinVig", DbType.String, C.FechFinVig)
                db.AddInParameter(cmd, "@User_Crea", DbType.String, C.User_Crea)
                db.ExecuteNonQuery(cmd)

                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Sub

    Public Function Listar_ProveedorFiscalizado(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Listar_ProveedorFiscalizado)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@Cod_Cia", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mostrar_ProveedorFiscalizado_X_Cod_Prov(ByVal pCod_Cia As String, ByVal pCod_Prov As String) As ETProveedorFiscalizado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Mostrar_ProveedorFiscalizado_X_Cod_Prov)

        Dim oPrvFisE As ETProveedorFiscalizado = Nothing

        Try
            oPrvFisE = New ETProveedorFiscalizado

            db.AddInParameter(cmd, "@Cod_Cia", DbType.String, pCod_Cia)
            db.AddInParameter(cmd, "@Cod_Prov", DbType.String, pCod_Prov)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    oPrvFisE.Cod_Cia = dr.GetString(dr.GetOrdinal("Cod_Cia"))
                    oPrvFisE.Cod_Prov = dr.GetString(dr.GetOrdinal("Cod_Prov"))
                    oPrvFisE.RazSoc = dr.GetString(dr.GetOrdinal("RazSoc"))
                    oPrvFisE.RUC = dr.GetString(dr.GetOrdinal("RUC"))
                    oPrvFisE.FechIniVig = dr.GetDateTime(dr.GetOrdinal("FechIniVig"))
                    oPrvFisE.FechFinVig = dr.GetDateTime(dr.GetOrdinal("FechFinVig"))
                    oPrvFisE.Status = dr.GetString(dr.GetOrdinal("Status"))
                End While
                If dr IsNot Nothing Then dr.Close()
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        Finally
            Mostrar_ProveedorFiscalizado_X_Cod_Prov = oPrvFisE
            oPrvFisE = Nothing
        End Try
    End Function

    Public Function Actualizar_ProveedorFiscalizado(ByVal C As ETProveedorFiscalizado) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Actualizar_ProveedorFiscalizado)
        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@Cod_Prov", DbType.String, C.Cod_Prov)
                db.AddInParameter(cmd, "@FechIniVig", DbType.DateTime, C.FechIniVig)
                db.AddInParameter(cmd, "@FechFinVig", DbType.String, C.FechFinVig)
                db.AddInParameter(cmd, "@User_Modi", DbType.String, C.User_Modi)

                RPTA = db.ExecuteNonQuery(cmd)

                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
        Return RPTA
    End Function

    Public Function Anular_ProveedorFiscalizado(ByVal C As ETProveedorFiscalizado) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Anular_ProveedorFiscalizado)
        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@Cod_Prov", DbType.String, C.Cod_Prov)
                db.AddInParameter(cmd, "@User_Modi", DbType.String, C.User_Modi)

                RPTA = db.ExecuteNonQuery(cmd)

                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
        Return RPTA
    End Function

    Public Function Mostrar_Proveedor_X_Cod_Prov(ByVal pCod_Cia As String, ByVal pCod_Prov As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Mostrar_Proveedor_X_Cod_Prov)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@Cod_Cia", DbType.String, pCod_Cia)
            db.AddInParameter(cmd, "@Cod_Prov", DbType.String, pCod_Prov)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_Proveedores_Fiscalizar(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Listar_Proveedores_Fiscalizar)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@Cod_Cia", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function DatosIngresoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosIngresoIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@mes", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@año", DbType.Int32, C.año)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function DatosEliminaIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosEliminaIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@ID", DbType.Int32, C.id)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function PresentacionIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.PresentacionIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@AYO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@TIPO", DbType.String, C.TipoDoc)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function IngresaIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.IngresaIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@AYO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@PRESENTACION", DbType.String, C.Presentacion)
                db.AddInParameter(cmd, "@FECHA", DbType.Date, C.Fecha)
                db.AddInParameter(cmd, "@TIPO_MOV", DbType.String, C.tipo_mov)
                db.AddInParameter(cmd, "@TIPO", DbType.String, C.TipoDoc)
                db.AddInParameter(cmd, "@OBSERVACION", DbType.String, C.Observacion)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function TipoguiaSunat() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.TipoguiaSunat)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function DatosEgresoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosEgresoIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@mes", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@año", DbType.Int32, C.año)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)

            End Try
        End Using
    End Function

    Public Function DatosProduccionIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosProduccionIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@mes", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@año", DbType.Int32, C.año)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosUsoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosUsoIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@mes", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@año", DbType.Int32, C.año)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function EnviarCorreoSolicitud(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.EnviarCorreoSolicitud)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@opcion", DbType.String, C.cod_equipo)
                db.AddInParameter(cmd, "@nro_solicitud", DbType.String, C.Cod_Prov)
                db.AddInParameter(cmd, "@FilesAdjutos", DbType.String, C.Presentacion)
                db.AddInParameter(cmd, "@Usuario", DbType.String, C.User_Crea)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)

            End Try
        End Using
    End Function

    Public Function SolicitudPlanilla(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.SolicitudPlanilla)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@accion", DbType.String, C.cod_labor)
                db.AddInParameter(cmd, "@nro_solicitud", DbType.String, C.Cod_Prov)
                db.AddInParameter(cmd, "@cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@codSolicitud", DbType.String, C.cod_labor)
                db.AddInParameter(cmd, "@codTrabajador", DbType.String, C.cod_trabajador)
                db.AddInParameter(cmd, "@codArea", DbType.String, C.cod_area)
                db.AddInParameter(cmd, "@motivo", DbType.String, C.Observacion)
                db.AddInParameter(cmd, "@fechaLimite", DbType.Date, C.Fecha)
                db.AddInParameter(cmd, "@estado", DbType.String, C.Status)
                db.AddInParameter(cmd, "@usuario", DbType.String, C.User_Crea)
                db.AddInParameter(cmd, "@fecha", DbType.Date, C.Fecha_Crea)
                db.AddInParameter(cmd, "@userAprueba", DbType.String, C.gre_transp_nombre)
                db.AddInParameter(cmd, "@moneda", DbType.String, C.tipo_mov)
                db.AddInParameter(cmd, "@jefaturaAprueba", DbType.String, C.gre_chofer_nombres)
                db.AddInParameter(cmd, "@fechaApruebaTeso", DbType.Date, C.FechFinVig)
                db.AddInParameter(cmd, "@fechaApruebaJefa", DbType.Date, C.FechIniVig)
                db.AddInParameter(cmd, "@beneficiario", DbType.String, C.gre_dest_nombre)
                db.AddInParameter(cmd, "@nomBanco", DbType.String, C.gre_ptollegada_direccion)
                db.AddInParameter(cmd, "@nroDNI", DbType.String, C.gre_ptollegada_ruc_establecimiento)
                'db.AddInParameter(cmd, "@nroCuenta", DbType.String, C.gre_vehiculo_pri_nrotarjeta_circulacion)
                db.AddInParameter(cmd, "@nroCuenta", DbType.String, C.gre_ptollegada_direccion)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)

            End Try
        End Using
    End Function
    Public Function PedidoSuministro(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.PedidoSuministro_v3)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@OPE", DbType.Int32, C.Ope)
                db.AddInParameter(cmd, "@ID", DbType.Int32, C.id)
                db.AddInParameter(cmd, "@COD_AREA", DbType.String, C.cod_area)
                db.AddInParameter(cmd, "@COD_LABOR", DbType.String, C.cod_labor)
                db.AddInParameter(cmd, "@COD_CANTERA", DbType.String, C.cod_cantera)
                db.AddInParameter(cmd, "@COD_EQUIPO", DbType.String, C.cod_equipo)
                db.AddInParameter(cmd, "@COD_TRABAJADOR", DbType.String, C.cod_trabajador)
                db.AddInParameter(cmd, "@OBSERVACION", DbType.String, C.Observacion)
                db.AddInParameter(cmd, "@APROBADO", DbType.String, C.aprobado)
                db.AddInParameter(cmd, "@URGENTE", DbType.String, C.urgente)
                db.AddInParameter(cmd, "@MANTENIMIENTO", DbType.String, C.T_Mantenimiento)
                db.AddInParameter(cmd, "@ALM_DESTINO", DbType.String, C.cod_Almacen)
                db.AddInParameter(cmd, "@ANULADO", DbType.String, C.anulado)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, C.User_Crea)
                db.AddInParameter(cmd, "@ALM_SOLICITANTE", DbType.String, C.cod_Almacen_Solicitante)
                '/**/                
                '@pa_gre_id_motivo_traslado char(2),
                db.AddInParameter(cmd, "@pa_gre_id_motivo_traslado", DbType.String, C.gre_id_motivo_traslado)
                '@pa_gre_id_modalidad_traslado char(2),
                db.AddInParameter(cmd, "@pa_gre_id_modalidad_traslado", DbType.String, C.gre_id_modalidad_traslado)
                '@pa_gre_dest_id_doc_identidad char(2),
                db.AddInParameter(cmd, "@pa_gre_dest_id_doc_identidad", DbType.String, C.gre_dest_id_doc_identidad)
                '@pa_gre_dest_nro_doc_identidad char(15),
                db.AddInParameter(cmd, "@pa_gre_dest_nro_doc_identidad", DbType.String, C.gre_dest_nro_doc_identidad)
                '@pa_gre_dest_nombre char(250),
                db.AddInParameter(cmd, "@pa_gre_dest_nombre", DbType.String, C.gre_dest_nombre)
                '@pa_gre_ptollegada_direccion char(500),
                db.AddInParameter(cmd, "@pa_gre_ptollegada_direccion", DbType.String, C.gre_ptollegada_direccion)
                '@pa_gre_ptollegada_codubigeo char(6),
                db.AddInParameter(cmd, "@pa_gre_ptollegada_codubigeo", DbType.String, C.gre_ptollegada_codubigeo)
                '@pa_gre_ptollegada_ruc_establecimiento char(11),
                db.AddInParameter(cmd, "@pa_gre_ptollegada_ruc_establecimiento", DbType.String, C.gre_ptollegada_ruc_establecimiento)
                '@pa_gre_ptollegada_codestablecimiento char(4),
                db.AddInParameter(cmd, "@pa_gre_ptollegada_codestablecimiento", DbType.String, C.gre_ptollegada_codestablecimiento)
                '@pa_gre_transp_ruc char(11),
                db.AddInParameter(cmd, "@pa_gre_transp_ruc", DbType.String, C.gre_transp_ruc)
                '@pa_gre_transp_nombre char(250),
                db.AddInParameter(cmd, "@pa_gre_transp_nombre", DbType.String, C.gre_transp_nombre)
                '@pa_gre_chofer_id_doc_identidad char(2),
                db.AddInParameter(cmd, "@pa_gre_chofer_id_doc_identidad", DbType.String, C.gre_chofer_id_doc_identidad)
                '@pa_gre_chofer_nro_doc_identidad char(15),
                db.AddInParameter(cmd, "@pa_gre_chofer_nro_doc_identidad", DbType.String, C.gre_chofer_nro_doc_identidad)
                '@pa_gre_chofer_apellidos char(250),
                db.AddInParameter(cmd, "@pa_gre_chofer_apellidos", DbType.String, C.gre_chofer_apellidos)
                '@pa_gre_chofer_nombres char(250),
                db.AddInParameter(cmd, "@pa_gre_chofer_nombres", DbType.String, C.gre_chofer_nombres)
                '@pa_gre_chofer_nro_licencia char(10),
                db.AddInParameter(cmd, "@pa_gre_chofer_nro_licencia", DbType.String, C.gre_chofer_nro_licencia)
                '@pa_gre_vehiculo_indicador_traslado_M1 bit,
                db.AddInParameter(cmd, "@pa_gre_vehiculo_indicador_traslado_M1", DbType.Boolean, C.gre_vehiculo_indicador_traslado_M1)
                '@pa_gre_vehiculo_pri_placa char(8),
                db.AddInParameter(cmd, "@pa_gre_vehiculo_pri_placa", DbType.String, C.gre_vehiculo_pri_placa)
                '@pa_gre_vehiculo_pri_nrotarjeta_circulacion char(15),
                db.AddInParameter(cmd, "@pa_gre_vehiculo_pri_nrotarjeta_circulacion", DbType.String, C.gre_vehiculo_pri_nrotarjeta_circulacion)
                '@pa_gre_vehiculo_sec_placa char(8),
                db.AddInParameter(cmd, "@pa_gre_vehiculo_sec_placa", DbType.String, C.gre_vehiculo_sec_placa)
                '@pa_gre_vehiculo_sec_nrotarjeta_circulacion char(15),
                db.AddInParameter(cmd, "@pa_gre_vehiculo_sec_nrotarjeta_circulacion", DbType.String, C.gre_vehiculo_sec_nrotarjeta_circulacion)
                '@pa_gre_envio_nro_bultos int,
                db.AddInParameter(cmd, "@pa_gre_envio_nro_bultos", DbType.Int16, C.gre_envio_nro_bultos)
                '@pa_gre_envio_peso_bruto_carga_kgs decimal(12,3),
                db.AddInParameter(cmd, "@pa_gre_envio_peso_bruto_carga_kgs", DbType.Decimal, C.gre_envio_peso_bruto_carga_kgs)
                '@pa_gre_observacion char(250)
                db.AddInParameter(cmd, "@pa_gre_observacion", DbType.String, C.gre_observacion)
                'nroorden_trabajo
                db.AddInParameter(cmd, "@pa_nroorden_trabajo", DbType.String, C.nroorden_trabajo)

                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)

            End Try
        End Using
    End Function

    Public Function PedidoSuministro_Det(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.PedidoSuministro_Det)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@ID", DbType.Int32, C.id)
                db.AddInParameter(cmd, "@COD_PROD", DbType.String, C.Cod_Prod)
                db.AddInParameter(cmd, "@CANTIDAD", DbType.Decimal, C.Cantidad)
                db.AddInParameter(cmd, "@CANTERA", DbType.String, C.cod_cantera)
                db.AddInParameter(cmd, "@EQUIPO", DbType.String, C.cod_equipo)
                db.AddInParameter(cmd, "@TRABAJADOR", DbType.String, C.cod_trabajador)
                db.AddInParameter(cmd, "@STOCK", DbType.Decimal, C.Stock)
                db.AddInParameter(cmd, "@ANEXO3", DbType.String, C.cod_anexo3)
                'db.AddInParameter(cmd, "@partidapresupuestal", DbType.String, C.iduso)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function
    Public Function SolicitudPlanilla_Det(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.SolicitudPlanilla_Det)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@accion", DbType.String, C.cod_labor)
                db.AddInParameter(cmd, "@idDetalle", DbType.String, C.TipoDoc)
                db.AddInParameter(cmd, "@nro_solicitud", DbType.String, C._numsolicitud)
                db.AddInParameter(cmd, "@cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@codConcepto", DbType.String, C.Cod_Prod)
                db.AddInParameter(cmd, "@monto", DbType.Decimal, C.Monto)
                db.AddInParameter(cmd, "@descripcion", DbType.String, C.Observacion)

                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosGeneralIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosGeneralIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@mes", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@año", DbType.Int32, C.año)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosUsoBarbotinaIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosUsoBarbotinaIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@mes", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@año", DbType.Int32, C.año)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function


    Public Function DatosUsoLaboratorio(ByVal C As ETProveedorFiscalizado, ByVal Ls_Datos As List(Of ETProveedorFiscalizado)) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                For Each Row In Ls_Datos
                    Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.InsertaUsoLaboratorio)
                    db.AddInParameter(cmd, "@cia", DbType.String, Row.Cod_Cia)
                    db.AddInParameter(cmd, "@cod_prod", DbType.String, Row.Cod_Prod)
                    db.AddInParameter(cmd, "@fecha", DbType.DateTime, Row.Fecha)
                    db.AddInParameter(cmd, "@cantidad", DbType.Decimal, Row.Cantidad)
                    db.AddInParameter(cmd, "@unidad", DbType.String, Row.Unidad)
                    db.AddInParameter(cmd, "@observacion", DbType.String, Row.Observacion)
                    db.AddInParameter(cmd, "@user_crea", DbType.String, Row.User_Crea)
                    db.AddInParameter(cmd, "@saldo", DbType.Decimal, Row.Saldo)
                    db.AddInParameter(cmd, "@cod_sunat", DbType.String, Row.Cod_Sunat)
                    db.ExecuteNonQuery(cmd)
                Next

                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosSadosIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosSaldosIQBF)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@FECHAFIN", DbType.Date, C.Fecha)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function HtnrxPResentacion(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.HtnrxPResentacion)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                'db.AddInParameter(cmd, "@FECHAFIN", DbType.Date, C.Fecha)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function HtnrEquipos(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.HtnrEquipos)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@Producto", DbType.String, C.Produdcto)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosIngresoMineral(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosIngresoMineral)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, C.User_Crea)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosVentaMineral(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosVentaMineral)
        cmd.CommandTimeout = 6000
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, C.User_Crea)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosMorosidad(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosMorosidad)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@FECHA", DbType.DateTime, C.Fecha)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosMorosidadAp(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosMorosidadAp)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@FECHA", DbType.DateTime, C.Fecha)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function DatosAjustesEnt(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.DatosAjustesEnt)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@CODTRABAJADOR", DbType.String, C.cod_trabajador)
                db.AddInParameter(cmd, "@FECHA", DbType.DateTime, C.Fecha)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function AjustesDifCambio(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.AjustesDifCambio)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@OPE", DbType.Int32, C.Ope)
                db.AddInParameter(cmd, "@ID", DbType.Int32, C.id)
                db.AddInParameter(cmd, "@COD_TRABAJADOR", DbType.String, C.cod_trabajador)
                db.AddInParameter(cmd, "@MONTO", DbType.Double, C.Monto)
                db.AddInParameter(cmd, "@FECHA", DbType.DateTime, C.Fecha)
                db.AddInParameter(cmd, "@TIPO_MOV", DbType.String, C.tipo_mov)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, C.User_Crea)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ListarReintegros(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ListarReintegro)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@CODPLA", DbType.String, C.Cod_Prov)
                db.AddInParameter(cmd, "@xape1", DbType.String, "")
                db.AddInParameter(cmd, "@xape2", DbType.String, "")
                db.AddInParameter(cmd, "@xnom1", DbType.String, "")
                db.AddInParameter(cmd, "@xnom2", DbType.String, "")
                db.AddInParameter(cmd, "@moneda", DbType.String, "")
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ListarPendLiquidacion(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ListarPendLiquidacion)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@CODTRABAJADOR", DbType.String, C.Cod_Prov)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ListarAplicaciones(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ListarAplicaciones)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@CODTRABAJADOR", DbType.String, C.Cod_Prov)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function AplicaReintegros(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.AplicarReintegro)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@IDDOCINTERNO", DbType.Int32, C._iddocinterno)
                db.AddInParameter(cmd, "@SOLICITUD", DbType.String, C._numsolicitud)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, C.User_Crea)
                db.AddInParameter(cmd, "@TIPOCAMBIO", DbType.Decimal, C.Saldo)
                db.AddInParameter(cmd, "@MONEDA", DbType.String, C._moneda)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function QuitarAplicacion(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.QuitarAplicacion)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@IDDOCINTERNO", DbType.Int32, C._iddocinterno)
                db.AddInParameter(cmd, "@IDLIQUIDACION", DbType.Int32, C._idliquidacion)
                db.AddInParameter(cmd, "@MONTO", DbType.Decimal, C.Saldo)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ReporteViaticos(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ReporteViaticos)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ReporteSinSustento(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RPTSINSUSTENTO)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ReporteRH(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ReporteRH)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@AYO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function MineralFlete(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.MineralFlete)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@AYO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ReporteLimiteRH(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ReporteLimiteRH)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@AYO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ReporteRH_Resumen(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ReporteRH_Resumen)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@AYO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ListadoProvisiones(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.LISTARPROVISIONES)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ReporteDetalleViaticos(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ReporteDetalleViaticos)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@CODTRABAJADOR", DbType.String, C.Cod_Prov)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ConsultaRecibos(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ConsultaRecibos)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@TIPODOC", DbType.String, C.TipoDoc)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@MES2", DbType.Int32, C.mes2)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ConsultaDocumentosAprobados(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ConsultaDocumentosAprobados)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@TIPODOC", DbType.String, C.TipoDoc)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@MES2", DbType.Int32, C.mes2)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ConsultaCTRAplicaciones(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ConsultaCTRAplicaciones)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@FECHAINI", DbType.String, C.FechIniVig)
                db.AddInParameter(cmd, "@FECHAFIN", DbType.String, C.FechFinVig)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ConsultaCTRListaAnticipo(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ConsultaCTRListaAnticipo)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@IDCONTRATISTA", DbType.Int32, C.id)
                db.AddInParameter(cmd, "@FECHA", DbType.String, C.Fecha)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ConsultaCTRListaDocumento(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ConsultaCTRListaDocumento)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@IDCONTRATISTA", DbType.Int32, C.id)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function SolicitudAprobada(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.SolicitudAprobada)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@FECHA", DbType.DateTime, C.Fecha)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ReporteRendimiento(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.Reporte_Rendimiento)
        cmd.CommandTimeout = 500
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@pa_cod_cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "@pa_ano", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@pa_mes", DbType.Int32, C.mes)
                db.AddInParameter(cmd, "@pa_CodMolino", DbType.String, C.molino)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ReporteProyeccionVentaRuma(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RPT_PROYECCIONVENTARUMA)
        cmd.CommandTimeout = 500
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function INSERTA_USOBARBOTINA(ByVal C As ETProveedorFiscalizado) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.INSERTA_USOBARBOTINA)
        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddInParameter(cmd, "@IDUSO", DbType.Int32, C.iduso)
                db.AddInParameter(cmd, "@CODPRODUCTO", DbType.String, C.Cod_Prod)
                db.AddInParameter(cmd, "@PRODUCTO", DbType.String, C.Produdcto)
                db.AddInParameter(cmd, "@UNIDAD", DbType.String, "KGS")
                db.AddInParameter(cmd, "@CANTIDAD", DbType.Double, C.Cantidad)

                RPTA = db.ExecuteNonQuery(cmd)

                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
        Return RPTA
    End Function

    Public Function VerificaCierreIqbf(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.VerificaCierreIqbf)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, C.mes)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function RptIngresoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RptIngresoIQBF)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@fecha1", DbType.DateTime, C.FechIniVig)
                db.AddInParameter(cmd, "@fecha2", DbType.DateTime, C.FechFinVig)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function RptInventarioIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RptInventarioIQBF)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                'db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@FECHA", DbType.DateTime, C.Fecha)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function RptEgresoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RptEgresoIQBF)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@fecha1", DbType.DateTime, C.FechIniVig)
                db.AddInParameter(cmd, "@fecha2", DbType.DateTime, C.FechFinVig)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function RptProduccionIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RptProduccionIQBF)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@fecha1", DbType.DateTime, C.FechIniVig)
                db.AddInParameter(cmd, "@fecha2", DbType.DateTime, C.FechFinVig)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function RptUsoIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RptUsoIQBF)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@fecha1", DbType.DateTime, C.FechIniVig)
                db.AddInParameter(cmd, "@fecha2", DbType.DateTime, C.FechFinVig)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function RptGeneralIQBF(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.RptGeneralIQBF)
        cmd.CommandTimeout = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@fecha1", DbType.DateTime, C.FechIniVig)
                db.AddInParameter(cmd, "@fecha2", DbType.DateTime, C.FechFinVig)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function VerificaUserCierre(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.VerificaUserCierre)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, C.User_Crea)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using

    End Function

    Public Function ReporteDAC(ByVal C As ETProveedorFiscalizado) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ReporteDAC)
        cmd.CommandTimeout = 6000
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AÑO", DbType.Int32, C.año)
                db.AddInParameter(cmd, "@MES", DbType.Int32, 12)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, C.User_Crea)
                'db.ExecuteNonQuery(cmd)
                Return db.ExecuteDataSet(cmd) '.Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function ConsultaUsuariosDocumentos(ByVal C As ETProveedorFiscalizado) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.ConsultaUsuariosDocumentos)
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, C.User_Crea)
                Return db.ExecuteDataSet(cmd).Tables(0)
                Conexion.Close()

            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function
End Class
