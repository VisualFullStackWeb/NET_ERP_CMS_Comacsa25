Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Data.Common.DbTransaction
Imports System.Configuration
Imports System.Globalization
Public Class DAContratista
    Public Function ListarContratista(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarContratista)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarContratistaConsulta(ByVal pCod_Cia As String, ByVal tipo As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarContratistaConsulta)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, pCod_Cia)
            db.AddInParameter(cmd, "@TIPO", DbType.String, tipo)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function ListarFrecuencia(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarFrecuencia)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function ActualizaContratista(ByVal obj As ETContratista) As Int32
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ActualizaContratista)
        Dim lResult As ETMyLista = Nothing
        Dim RPTA As Integer = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
                db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
                db.AddInParameter(cmd, "@RUC", DbType.String, obj._ruc)
                'db.AddInParameter(cmd, "@IDCONTRATISTA", DbType.Int32, obj._idcontratista)
                db.AddInParameter(cmd, "@TIPOPAGO", DbType.String, obj._tipopago)
                db.AddInParameter(cmd, "@IDFRECPAGO", DbType.Int32, obj._idfrecpago)
                db.AddInParameter(cmd, "@CODBANCO", DbType.String, obj._banco)
                db.AddInParameter(cmd, "@NROCTA", DbType.String, obj._nrocta)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
                db.AddInParameter(cmd, "@SUPERVISOR", DbType.String, obj.supervisor)
                db.AddInParameter(cmd, "@CONTADOR", DbType.String, obj.contador)
                db.AddInParameter(cmd, "@RENTA", DbType.Int32, obj.renta)
                db.AddInParameter(cmd, "@CORREO", DbType.String, obj.Email)
                RPTA = db.ExecuteNonQuery(cmd, Trans)

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try

        End Using
        Return RPTA
    End Function

    Public Function ListarCantera(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarCantera)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarSupervisor_Contratista(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarSupervisor_Contratista)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarAfp(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarAfp)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarTipodoc(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarTipodoc)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function FechaSemana(ByVal obj As ETContratista) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.FechaSemana)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@SEMANA", DbType.Int32, obj._semana)
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, obj._tipo)

            Return db.ExecuteDataSet(cmd)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function Mant_Planilla(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Mant_Planilla)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, obj._tipo)
            db.AddInParameter(cmd, "@FLGCESE", DbType.Int32, obj._flgcese)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDTRABAJADOR", DbType.Int32, obj._idtrabajador)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
            db.AddInParameter(cmd, "@TIPO_DOCUMENTO", DbType.String, obj._tipodocumento)
            db.AddInParameter(cmd, "@NRODOCUMENTO", DbType.String, obj._documento)
            db.AddInParameter(cmd, "@AP_PAT", DbType.String, obj._apepat)
            db.AddInParameter(cmd, "@AP_MAT", DbType.String, obj._apemat)
            db.AddInParameter(cmd, "@NOMBRES", DbType.String, obj._nombres)
            db.AddInParameter(cmd, "@FECHAINGRESO", DbType.Date, obj._fechaingreso)
            db.AddInParameter(cmd, "@FECHACESE", DbType.Date, obj._fechacese)
            db.AddInParameter(cmd, "@SUELDOBASICO", DbType.Decimal, obj._sueldo)
            db.AddInParameter(cmd, "@BONIFICACION", DbType.Decimal, obj._bonificacion)
            db.AddInParameter(cmd, "@CODAFP", DbType.String, obj._codafp)
            db.AddInParameter(cmd, "@FLAGESSALUD", DbType.String, obj._flgessalud)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarPlanilla(ByVal pCod_Cia As String, ByVal cod_prov As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarPlanilla)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, pCod_Cia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, cod_prov)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarPlanillaTrabajador(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarPlanillaTrabajador)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDTRABAJADOR", DbType.Int32, obj._idtrabajador)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function ListarMineralContratista(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarMineralContratista)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarBanco() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarBanco)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mant_Conceptos(ByVal obj As ETContratista) As Int32

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Mant_Conceptos)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, obj._tipo)
            db.AddInParameter(cmd, "@ID", DbType.Int32, obj._idtrabajador)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@DESCRIPCION", DbType.String, obj._descripcion)
            db.AddInParameter(cmd, "@TIPOANTICIPO", DbType.String, obj._tipoanticipo)
            db.AddInParameter(cmd, "@DESCTIPO", DbType.String, obj._desctipoanticipo)
            db.AddInParameter(cmd, "@FLAGVARIACION", DbType.String, obj._variacion)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteNonQuery(cmd)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listarconceptos(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listarconceptos)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPOLISTADO", DbType.Int32, obj._tipo)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@TIPOANTICIPO", DbType.String, obj._tipoanticipo)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarIQBFkardex() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarIQBFkardex)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@TIPOLISTADO", DbType.Int32, obj._tipo)
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "@TIPOANTICIPO", DbType.String, obj._tipoanticipo)
            'db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarValidaProduccion(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarValidaProduccion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CODCIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA1", DbType.Date, obj.FechaInicio)
            db.AddInParameter(cmd, "@FECHA2", DbType.Date, obj.FechaTerminacion)
            db.AddInParameter(cmd, "@LIBERADO", DbType.Int32, obj.liberado)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function ListarValidaVTAProduccion(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarValidaVTAProduccion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CODCIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA1", DbType.Date, obj.FechaInicio)
            db.AddInParameter(cmd, "@FECHA2", DbType.Date, obj.FechaTerminacion)
            db.AddInParameter(cmd, "@PENDIENTE", DbType.Int32, obj.liberado)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MantValidaProduccion(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.MantValidaProduccion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@BILLETE", DbType.String, obj._billete)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, obj._cod_prod)
            db.AddInParameter(cmd, "@VALIDACION", DbType.Int32, obj.validacion_)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj.Usuario)
            db.AddInParameter(cmd, "@COMENTARIOS", DbType.String, obj.Comentarios)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function MantValidaVTAProduccion(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.MantValidaVTAProduccion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@BILLETE", DbType.String, obj._billete)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, obj._cod_prod)
            db.AddInParameter(cmd, "@OBS_VENTAS", DbType.String, obj.cadena)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj.Usuario)
            db.AddInParameter(cmd, "@ATENDIDO", DbType.Int32, obj.validacion_)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function RegistrarModificarObsProduccion(ByVal obj As ETContratista) As Int32
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.RegistrarModificarObsProduccion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@BILLETE", DbType.String, obj._billete)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, obj._cod_prod)
            db.AddInParameter(cmd, "@OBS_PRODUCCION", DbType.String, obj._observacion)
            'Return db.ExecuteDataSet(cmd).Tables(0)
            Return db.ExecuteNonQuery(cmd)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try
    End Function






    Public Function ListarIQBFkardexMov(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarIQBFkardexMov)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, obj._cod_prod)
            db.AddInParameter(cmd, "@COD_SUNAT", DbType.String, obj._cod_sunat)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarIQBFRPTkardex(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarIQBFRPTkardex)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, obj._cod_prod)
            db.AddInParameter(cmd, "@COD_SUNAT", DbType.String, obj._cod_sunat)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function IngresoIQBFkardex(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.IngresoIQBFkardex)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@OPE", DbType.Int32, obj.Operacion)
            db.AddInParameter(cmd, "@ID", DbType.Int32, obj._id)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, obj._cod_prod)
            db.AddInParameter(cmd, "@COD_SUNAT", DbType.String, obj._cod_sunat)
            db.AddInParameter(cmd, "@MOVI", DbType.String, obj._movi)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, obj.Fecha)
            db.AddInParameter(cmd, "@CANTIDAD", DbType.Double, obj.Cantidad)
            db.AddInParameter(cmd, "@MARCA", DbType.String, obj._marca)
            db.AddInParameter(cmd, "@CONCENTRACION", DbType.String, obj._concentracion)
            db.AddInParameter(cmd, "@OBSERVACION", DbType.String, obj._observacion)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj.Usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listarconceptos_Fact(ByVal idfactura As Int32) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listarconceptos_Fact)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "@ID_FACTURA", DbType.Int32, idfactura)
            Return db.ExecuteDataSet(cmd).Tables(0)
        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mantconceptos_Fact_Cab(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Mantconceptos_Fact_Cab)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "@OPE", DbType.Int32, obj.TipoOperacion)
            db.AddInParameter(cmd, "@ID_FACTURA", DbType.Int32, obj.ID)
            db.AddInParameter(cmd, "@IDCONTRATISTA", DbType.Int32, obj._idcontratista)
            db.AddInParameter(cmd, "@ID_SUPERVISOR", DbType.Int32, obj.IDSUPERVISOR)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, obj.Fecha)
            db.AddInParameter(cmd, "@OBSERVACION", DbType.String, obj._observacion)
            db.AddInParameter(cmd, "@VALOR_VTA", DbType.Decimal, obj._valorvta)
            db.AddInParameter(cmd, "@IGV", DbType.Decimal, obj._igv)
            db.AddInParameter(cmd, "@TOTAL", DbType.Decimal, obj.montoTotal)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)
        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mantconceptos_Fact_Det(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Mantconceptos_Fact_Det)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "@ID_FACTURA", DbType.Int32, obj.ID)
            db.AddInParameter(cmd, "@ID_CONCEPTO", DbType.Int32, obj._idconcepto)
            db.AddInParameter(cmd, "@VALOR_VTA", DbType.Decimal, obj._valorvta)
            db.AddInParameter(cmd, "@IGV", DbType.Decimal, obj._igv)
            db.AddInParameter(cmd, "@TOTAL", DbType.Decimal, obj.montoTotal)
            Return db.ExecuteDataSet(cmd).Tables(0)
        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarPrecioMineral() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarPrecioMineral)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarConceptoFact() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarConceptoFact)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mant_PrecioMineral(ByVal obj As ETContratista) As Int32

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Mant_PrecioMineral)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, obj._codprod)
            db.AddInParameter(cmd, "@PRECIO", DbType.Decimal, obj._precio)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteNonQuery(cmd)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mant_ConceptoFact(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Mant_ConceptoFact)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@OPE", DbType.Int32, obj.Operacion)
            db.AddInParameter(cmd, "@ID_CONCEPTO", DbType.Int32, obj.ID)
            db.AddInParameter(cmd, "@CONCEPTO", DbType.String, obj._descripcion)
            db.AddInParameter(cmd, "@CUENTA", DbType.String, obj.Cuenta)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function IngresoMineralFecha(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.IngresoMineralFecha)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, obj._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, obj._fecha2)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@ID_SUPERVISOR", DbType.Int32, obj.IDSUPERVISOR)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarImpuestos(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarImpuestos)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarSaldoImpuestos(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarSaldoImpuestos)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDCONTRATISTA", DbType.String, obj._idcontratista)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarSaldoImpuestosAnticipo(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarSaldoImpuestosAnticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDCONTRATISTA", DbType.String, obj._idcontratista)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MantSuspension(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.MantSuspension)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, obj._tipo)
            db.AddInParameter(cmd, "@ID", DbType.Int32, obj._id)
            db.AddInParameter(cmd, "@RUC", DbType.String, obj._ruc)
            db.AddInParameter(cmd, "@RAZON", DbType.String, obj._nombres)
            db.AddInParameter(cmd, "@FECHA", DbType.String, obj._fecha1)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MantRetencionRH(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.MantRetencionRH)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, obj._tipo)
            db.AddInParameter(cmd, "@ID", DbType.Int32, obj._id)
            db.AddInParameter(cmd, "@RUC", DbType.String, obj._ruc)
            db.AddInParameter(cmd, "@RAZON", DbType.String, obj._nombres)
            db.AddInParameter(cmd, "@SERIE", DbType.String, obj._serie)
            db.AddInParameter(cmd, "@NUMERO", DbType.String, obj._documento)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MantReciboRH(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.MantReciboRH)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, obj._tipo)
            db.AddInParameter(cmd, "@ID", DbType.Int32, obj._id)
            db.AddInParameter(cmd, "@CONCEPTO", DbType.String, obj._descripcion)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MantFechaViatico(ByVal obj As ETContratista) As Int32

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.MantFechaViatico)
        Dim lResult As ETMyLista = Nothing
        Dim RPTA As Integer = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "@IDLIQUIDACION", DbType.Int32, obj._id)
                db.AddInParameter(cmd, "@FECHAVIATICO", DbType.String, obj._fecha1)
                db.AddInParameter(cmd, "@FLGTERCERO", DbType.String, obj._flgtercero)
                db.AddInParameter(cmd, "@DIAS", DbType.Int32, obj._ndias)
                db.AddInParameter(cmd, "@COMENTARIO", DbType.String, obj._comentario)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)

                RPTA = db.ExecuteNonQuery(cmd, Trans)

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return 0
            End Try

        End Using

        Return RPTA

    End Function

    Public Function ImportarPlanilla(ByVal obj As ETContratista) As Int32

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ImportarPlanilla)
        Dim lResult As ETMyLista = Nothing
        Dim RPTA As Integer = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "@TIPO_DOCUMENTO", DbType.String, obj._tipodocumento)
                db.AddInParameter(cmd, "@NRODOCUMENTO", DbType.String, obj._documento)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
                db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
                db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
                db.AddInParameter(cmd, "@QUINCENA", DbType.Int32, obj._quincena)
                db.AddInParameter(cmd, "@SEMANAINI", DbType.Int32, obj._semanaini)
                db.AddInParameter(cmd, "@SEMANAFIN", DbType.Int32, obj._semanafin)
                db.AddInParameter(cmd, "@FECHAINI", DbType.DateTime, obj._fecha1)
                db.AddInParameter(cmd, "@FECHAFIN", DbType.DateTime, obj._fecha2)
                db.AddInParameter(cmd, "@REMUNERACION", DbType.Decimal, obj._sueldo)
                db.AddInParameter(cmd, "@TOTALPAGO", DbType.Decimal, obj._pago)
                db.AddInParameter(cmd, "@ONP", DbType.Decimal, obj._onp)
                db.AddInParameter(cmd, "@AFP", DbType.Decimal, obj._afp)
                db.AddInParameter(cmd, "@ESSALUD", DbType.Decimal, obj._essalud)
                db.AddInParameter(cmd, "@QUINTA", DbType.Decimal, obj._quinta)
                db.AddInParameter(cmd, "@SCTR", DbType.Decimal, obj._sctr)
                db.AddInParameter(cmd, "@AFPCOMP", DbType.Decimal, obj._afpcomp)
                db.AddInParameter(cmd, "@FMINERO", DbType.Decimal, obj._fminero)
                db.AddInParameter(cmd, "@SCTR_SALUD", DbType.Decimal, obj._sctr_salud)
                db.AddInParameter(cmd, "@ESSALUD_VIDA", DbType.Decimal, obj._essalud_vida)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
                RPTA = db.ExecuteScalar(cmd, Trans)

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return 0
            End Try

        End Using

        Return RPTA

    End Function

    Public Function ListarSeteoExcel() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarSeteoExcel)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function IngresoPlanillaFecha(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.IngresoPlanillaFecha)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, obj._tipo)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@QUINCENA", DbType.Int32, obj._quincena)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListaPlanillaFechaContratisa(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListaPlanillaFechaContratisa)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, obj._tipo)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@QUINCENA", DbType.Int32, obj._quincena)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarBeneficiarioDni(ByVal Rpt As ETContratista) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Ctr_BeneficiarioDni)

        Try
            db.AddInParameter(cmd, "nrodni", DbType.String, Rpt.dnibeneficiario)
            db.AddInParameter(cmd, "moneda ", DbType.String, Rpt.moneda)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .beneficiario = dr.GetString(dr.GetOrdinal("nombre"))
                        .bancobeneficiario = dr.GetString(dr.GetOrdinal("banco"))
                        .ctabeneficiario = dr.GetString(dr.GetOrdinal("nrocta"))
                        'If Rpt.Tipo = 7 Then
                        '    .Unidad = dr.GetString(dr.GetOrdinal("UM"))
                        'End If
                    End With
                    lResult.Ls_Entrega.Add(Entidad.Entregas)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function

    Public Function MantenimientoAnticipo(ByVal Rpt As ETContratista, ByVal Ls_Entrega As List(Of ETContratista), ByVal Ls_EntregaDetalle As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoAnticipo)

                db.AddInParameter(cmd, "tipo", DbType.Int16, Rpt.TipoOperacion)
                db.AddInParameter(cmd, "cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "nrosolicitud", DbType.String, Rpt.NumSolicitud)
                db.AddInParameter(cmd, "TIPOANTICIPO", DbType.String, Rpt._tipoanticipo)
                db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt._ayo)
                db.AddInParameter(cmd, "MES", DbType.Int32, Rpt._mes)
                db.AddInParameter(cmd, "QUINCENA", DbType.Int32, Rpt._quincena)
                db.AddInParameter(cmd, "SEMANAINI", DbType.Int32, Rpt._semanaini)
                db.AddInParameter(cmd, "SEMANAFIN", DbType.Int32, Rpt._semanafin)
                db.AddInParameter(cmd, "IDCONTRATISTA", DbType.Int32, Rpt._idcontratista)
                db.AddInParameter(cmd, "DESCRIPCION", DbType.String, Rpt._descripcion)
                db.AddInParameter(cmd, "FECHA", DbType.DateTime, Rpt._fecha1)

                db.AddInParameter(cmd, "total", DbType.Double, Rpt.montoTotal)
                db.AddInParameter(cmd, "estado", DbType.Int32, Rpt.idEstado)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt._usuario)

                db.AddInParameter(cmd, "moneda", DbType.String, Rpt.moneda)
                db.AddInParameter(cmd, "flgbeneficiario", DbType.String, Rpt.flgbeneficiario)
                db.AddInParameter(cmd, "dnibeneficiario", DbType.String, Rpt.dnibeneficiario)
                db.AddInParameter(cmd, "beneficiario", DbType.String, Rpt.beneficiario)
                db.AddInParameter(cmd, "tipodepobeneficiario", DbType.String, Rpt.tipodepobeneficiario)
                db.AddInParameter(cmd, "bancobeneficiario", DbType.String, Rpt.bancobeneficiario)
                db.AddInParameter(cmd, "ctabeneficiario", DbType.String, Rpt.ctabeneficiario)
                db.AddInParameter(cmd, "NUMORDEN", DbType.String, Rpt._numorden)
                db.AddInParameter(cmd, "NUMCONTRATO", DbType.String, Rpt._numcontrato)
                db.AddInParameter(cmd, "OBSERVACION", DbType.String, Rpt._observacion)
                db.AddInParameter(cmd, "ID_SUPERVISOR", DbType.String, Rpt.IDSUPERVISOR)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.AddParameter(cmd, "nsolicitud", DbType.String, 8, ParameterDirection.InputOutput, True, 0, 0, "", DataRowVersion.Default, Rpt.NumSolicitud)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                lResult.NumSolicitud = Convert.ToString(db.GetParameterValue(cmd, "nsolicitud"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

                If Rpt.TipoOperacion <> 3 Then 'And Rpt.idEstado = 1 Then
                    For Each Row In Ls_EntregaDetalle

                        Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoAnticipoDeta)
                        db.AddInParameter(xmd, "tipo", DbType.Int16, Rpt.TipoOperacion)
                        db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                        If Rpt.TipoOperacion = 1 Then
                            db.AddInParameter(xmd, "numsolicitud", DbType.String, lResult.NumSolicitud)
                        Else
                            db.AddInParameter(xmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
                        End If
                        db.AddInParameter(xmd, "IDConcepto", DbType.String, Row._idconcepto)
                        db.AddInParameter(xmd, "flgvariacion", DbType.String, Row._variacion)
                        db.AddInParameter(xmd, "monto", DbType.Double, Row.montoTotal)
                        db.AddInParameter(xmd, "numfactura", DbType.String, Row._documento)
                        db.AddInParameter(xmd, "fechafactura", DbType.DateTime, Row.Fecha)
                        db.AddInParameter(xmd, "ruc", DbType.String, Row._ruc)
                        db.AddInParameter(xmd, "razon", DbType.String, Row._razon)
                        db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                        db.ExecuteNonQuery(xmd, Trans)

                        lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                        If lResult.Respuesta <> 0 Then Err.Raise(10)
                    Next
                End If


                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarMonedas() As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Monedas)
        Dim lResult As ETMyLista = Nothing
        Try
            'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Contratista = New ETContratista
                    With Entidad.Contratista
                        .codmoneda = dr.GetString(dr.GetOrdinal("cod_maestro2"))
                        .moneda = dr.GetString(dr.GetOrdinal("descrip"))
                        'If Rpt.Tipo = 7 Then
                        '    .Unidad = dr.GetString(dr.GetOrdinal("UM"))
                        'End If
                    End With
                    lResult.Ls_Anticipo.Add(Entidad.Contratista)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function

    Public Function ListarAnticipos(ByVal Rpt As ETContratista) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_SolicitudesAnticipo)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "tipoanticipo", DbType.String, Rpt._tipoanticipo)
            db.AddInParameter(cmd, "fechainicio", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "fechafin", DbType.DateTime, Rpt._fecha2)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Contratista = New ETContratista
                    With Entidad.Contratista
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        ._idcontratista = dr.GetInt32(dr.GetOrdinal("IDCONTRATISTA"))
                        ._contratista = dr.GetString(dr.GetOrdinal("CONTRATISTA"))
                        ._codcantera = dr.GetString(dr.GetOrdinal("CODCANTERA"))
                        ._cantera = dr.GetString(dr.GetOrdinal("CANTERA"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("FECHACREA"))
                        ._descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        .moneda = dr.GetString(dr.GetOrdinal("moneda"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .Estado = dr.GetString(dr.GetOrdinal("estado"))
                        .Usuario = dr.GetString(dr.GetOrdinal("usuario"))
                        .periodo = dr.GetString(dr.GetOrdinal("PERIODO"))
                        '.IDSUPERVISOR = dr.GetString(dr.GetOrdinal("ID_SUPERVISOR"))
                        '.supervisor = dr.GetString(dr.GetOrdinal("SUPERVISOR"))
                        'If Rpt.Tipo = 7 Then
                        '    .Unidad = dr.GetString(dr.GetOrdinal("UM"))
                        'End If
                    End With
                    lResult.Ls_Anticipo.Add(Entidad.Contratista)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function

    Public Function SolicitudAnticipoxNumero(ByVal Rpt As ETContratista) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.SolicitudAnticipoxNumero)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Contratista = New ETContratista
                    With Entidad.Contratista
                        ._tipopago = dr.GetString(dr.GetOrdinal("TIPOPAGO"))
                        ._idfrecpago = dr.GetInt32(dr.GetOrdinal("IDFRECPAGO"))
                        ._ayo = dr.GetInt32(dr.GetOrdinal("AYO"))
                        ._mes = dr.GetInt32(dr.GetOrdinal("MES"))
                        ._quincena = dr.GetInt32(dr.GetOrdinal("QUINCENA"))
                        ._semanaini = dr.GetInt32(dr.GetOrdinal("SEMANAINI"))
                        ._semanafin = dr.GetInt32(dr.GetOrdinal("SEMANAFIN"))
                        ._idcontratista = dr.GetInt32(dr.GetOrdinal("IDCONTRATISTA"))
                        ._codprov = dr.GetString(dr.GetOrdinal("COD_PROV"))
                        ._contratista = dr.GetString(dr.GetOrdinal("CONTRATISTA"))
                        ._codcantera = dr.GetString(dr.GetOrdinal("CODCANTERA"))
                        ._cantera = dr.GetString(dr.GetOrdinal("CANTERA"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("FECHACREA"))
                        ._descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .idEstado = dr.GetInt32(dr.GetOrdinal("estado"))
                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
                        ._banco = dr.GetString(dr.GetOrdinal("banco"))
                        ._nrocta = dr.GetString(dr.GetOrdinal("nro_cta"))
                        .nrodoc = dr.GetString(dr.GetOrdinal("nro_doc"))
                        .moneda = dr.GetString(dr.GetOrdinal("moneda"))
                        .flgbeneficiario = dr.GetString(dr.GetOrdinal("flgbeneficiario"))
                        .dnibeneficiario = dr.GetString(dr.GetOrdinal("dnibeneficiario"))
                        .beneficiario = dr.GetString(dr.GetOrdinal("beneficiario"))
                        .tipodepobeneficiario = dr.GetString(dr.GetOrdinal("tipodepobeneficiario"))
                        .bancobeneficiario = dr.GetString(dr.GetOrdinal("bancobeneficiario"))
                        .ctabeneficiario = dr.GetString(dr.GetOrdinal("ctabeneficiario"))
                        .bcotrabajador = dr.GetString(dr.GetOrdinal("pagobanco"))
                        .ctatrabajador = dr.GetString(dr.GetOrdinal("pagonumcta"))
                        ._numorden = dr.GetString(dr.GetOrdinal("numorden"))
                        ._numcontrato = dr.GetString(dr.GetOrdinal("numcontrato"))
                        ._observacion = dr.GetString(dr.GetOrdinal("observacion"))
                        .renta = dr.GetInt32(dr.GetOrdinal("RENTA"))
                        .IDSUPERVISOR = dr.GetInt32(dr.GetOrdinal("ID_SUPERVISOR"))
                        .supervisor = dr.GetString(dr.GetOrdinal("SUPERVISOR"))
                    End With
                    lResult.Ls_Anticipo.Add(Entidad.Contratista)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function

    Public Function InsertaMineralAnticipo(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaMineralAnticipo)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "NUMSOLICITUD", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "NUMDOC", DbType.String, Row._billete)
                    db.AddInParameter(xmd, "TOTALTONELADAS", DbType.Double, Row._toneladas)
                    db.AddInParameter(xmd, "COD_MATPRIMA", DbType.String, Row._codmineral)
                    db.AddInParameter(xmd, "MINERAL", DbType.String, Row._mineral)
                    db.AddInParameter(xmd, "PRECIO", DbType.Double, Row._precio)
                    db.AddInParameter(xmd, "TOTAL", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "FECHA", DbType.DateTime, Row.FechaIngreso)
                    db.AddInParameter(xmd, "PRECIOFACTURA", DbType.Double, Row._preciofactura)
                    db.AddInParameter(xmd, "PORCENTAJE", DbType.Double, Row._porcentaje)
                    db.AddInParameter(xmd, "COMENTARIO", DbType.String, Row._comentario)
                    db.AddInParameter(xmd, "BILLETEREF", DbType.String, Row._billeteref)
                    db.AddInParameter(xmd, "ACTIVO", DbType.Int32, Row.activo)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarMineralAniticipo(ByVal numsolicitud As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarMineralAniticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, numsolicitud)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarCTR_Factura() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarCTR_Factura)
        Dim lResult As ETMyLista = Nothing

        Try
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function validaPeriodo(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.validaPeriodo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "TIPOANTICIPO", DbType.String, obj._tipoanticipo)
            db.AddInParameter(cmd, "AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "QUINCENA", DbType.Int32, obj._quincena)
            db.AddInParameter(cmd, "SEMANAINI", DbType.Int32, obj._semanaini)
            db.AddInParameter(cmd, "SEMANAFIN", DbType.Int32, obj._semanafin)
            db.AddInParameter(cmd, "IDCONTRATISTA", DbType.Int32, obj._idcontratista)
            db.AddInParameter(cmd, "IDSUPERVISOR", DbType.Int32, obj.IDSUPERVISOR)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function validaPeriodoPlanilla(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.validaPeriodoPlanilla)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "TIPOANTICIPO", DbType.String, obj._tipoanticipo)
            db.AddInParameter(cmd, "AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "QUINCENA", DbType.Int32, obj._quincena)
            db.AddInParameter(cmd, "SEMANAINI", DbType.Int32, obj._semanaini)
            db.AddInParameter(cmd, "SEMANAFIN", DbType.Int32, obj._semanafin)
            db.AddInParameter(cmd, "IDCONTRATISTA", DbType.Int32, obj._idcontratista)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function InsertaPlanillaAnticipo(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaPlanillaAnticipo)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "NUMSOLICITUD", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "IDTRABAJADOR", DbType.Int32, Row._idtrabajador)
                    db.AddInParameter(xmd, "REMUNERACION", DbType.Double, Row._sueldo)
                    db.AddInParameter(xmd, "TOTALPAGO", DbType.Double, Row._pago)
                    db.AddInParameter(xmd, "ONP", DbType.Double, Row._onp)
                    db.AddInParameter(xmd, "AFP", DbType.Double, Row._afp)
                    db.AddInParameter(xmd, "ESSALUD", DbType.Double, Row._essalud)
                    db.AddInParameter(xmd, "QUINTA", DbType.Double, Row._quinta)
                    db.AddInParameter(xmd, "SCTR", DbType.Double, Row._sctr)
                    db.AddInParameter(xmd, "AFPCOMP", DbType.Double, Row._afpcomp)
                    db.AddInParameter(xmd, "FMINERO", DbType.Double, Row._fminero)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarPlanillaAniticipo(ByVal numsolicitud As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarPlanillaAniticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, numsolicitud)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function billeteExistente(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.billeteExistente)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, obj._fecha1)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@NUMDOC", DbType.String, obj._billete)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarObligaciones(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarObligaciones)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@CODPROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
            db.AddInParameter(cmd, "@NROGRUPO", DbType.Int32, obj._tipo)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function detalleObligaciones(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.detalleObligaciones)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@CODPROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
            db.AddInParameter(cmd, "@NOMBRECAMPO", DbType.String, obj._descripcion)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ImportarGratiCts(ByVal obj As ETContratista) As Int32

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ImportarGratiCts)
        Dim lResult As ETMyLista = Nothing
        Dim RPTA As Integer = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "@TIPO_DOCUMENTO", DbType.String, obj._tipodocumento)
                db.AddInParameter(cmd, "@NRODOCUMENTO", DbType.String, obj._documento)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
                db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
                db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
                db.AddInParameter(cmd, "@TIPO", DbType.String, obj._tipoanticipo)
                db.AddInParameter(cmd, "@REMUNERACION", DbType.Decimal, obj._sueldo)                
                db.AddInParameter(cmd, "@GRATIFICACION", DbType.Decimal, obj._gratificacion)
                db.AddInParameter(cmd, "@CTS", DbType.Decimal, obj._cts)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
                RPTA = db.ExecuteScalar(cmd, Trans)

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return 0
            End Try

        End Using

        Return RPTA

    End Function

    Public Function IngresoGratiCtsFecha(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.IngresoGratiCtsFecha)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.String, obj._tipoanticipo)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function InsertaGratiCtsAnticipo(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaGratiCtsAnticipo)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "NUMSOLICITUD", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "IDTRABAJADOR", DbType.Int32, Row._idtrabajador)
                    db.AddInParameter(xmd, "REMUNERACION", DbType.Double, Row._sueldo)
                    db.AddInParameter(xmd, "GRATIFICACION", DbType.Double, Row._gratificacion)
                    db.AddInParameter(xmd, "CTS", DbType.Double, Row._cts)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarGratificacionAniticipo(ByVal obj As ETContratista) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarGratificacionAniticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.String, obj._tipoanticipo)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function EliminaPlanillaPeriodo(ByVal obj As ETContratista) As Int32

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.EliminaPlanillaPeriodo)
        Dim lResult As ETMyLista = Nothing
        Dim RPTA As Integer = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "@TIPO", DbType.String, obj._tipoanticipo)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
                db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
                db.AddInParameter(cmd, "@QUINCENA", DbType.Int32, obj._quincena)
                db.AddInParameter(cmd, "@SEMANAINI", DbType.Int32, obj._semanaini)
                db.AddInParameter(cmd, "@SEMANAFIN", DbType.Int32, obj._semanafin)
                db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
                db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)
                RPTA = db.ExecuteScalar(cmd, Trans)

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return 0
            End Try

        End Using

        Return RPTA

    End Function

    Public Function UsuarioAprobacion(ByVal Rpt As ETContratista) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CTR_UsuarioAprobacion)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Contratista = New ETContratista
                    With Entidad.Contratista
                        .Usuario = dr.GetString(dr.GetOrdinal("usuario"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("fecha_crea"))
                    End With
                    lResult.Ls_Anticipo.Add(Entidad.Contratista)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function

    Public Function InsertaImpuestoAnticipo(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaImpuestoAnticipo)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "NUMSOLICITUD", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "TIPODOC", DbType.String, Row._tipodocumento)
                    db.AddInParameter(xmd, "NUMDOC", DbType.String, Row._documento)
                    db.AddInParameter(xmd, "FECHADOC", DbType.DateTime, Row.Fecha)
                    db.AddInParameter(xmd, "OPERACION", DbType.String, Row._tipoanticipo)
                    db.AddInParameter(xmd, "VALORVTA", DbType.Double, Row._valorvta)
                    db.AddInParameter(xmd, "IGV", DbType.Double, Row._igv)
                    db.AddInParameter(xmd, "VALOR", DbType.Double, Row._valor)
                    db.AddInParameter(xmd, "ORDEN", DbType.Int32, Row._orden)
                    db.AddInParameter(xmd, "RENTA", DbType.Int32, Row.renta)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function
    Public Function CargarImpuestoAnticipo(ByVal obj As ETContratista) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CargarImpuestoAnticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function InsertaObligacionAnticipo(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaObligacionAnticipo)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "NUMSOLICITUD", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "IDOBLIGACION", DbType.Int32, Row.ID)
                    db.AddInParameter(xmd, "TOTAL", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "DSCTO", DbType.Double, Row.dscto)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function CargarObligacionAnticipo(ByVal obj As ETContratista) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CargarObligacionAnticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function InsertaSaldoUtilizado(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaSaldoUtilizado)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "NUMSOLICITUD", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "IDCONTRATISTA", DbType.Int32, Row._idcontratista)
                    db.AddInParameter(xmd, "AYO", DbType.Int32, Row._ayo)
                    db.AddInParameter(xmd, "MES", DbType.Int32, Row._mes)
                    db.AddInParameter(xmd, "MONTO", DbType.Double, Row.montoTotal)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarTrabajadorContratista(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarTrabajadorContratista)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@CODPROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._codcantera)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Verifica_Trabajador_Liquidacion(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Verifica_Trabajador_Liquidacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@IDTRABAJADOR", DbType.Int32, obj._idtrabajador)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function InsertaVacacionesAnticipo(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaVacacionesAnticipo)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "NUMSOLICITUD", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "IDTRABAJADOR", DbType.Int32, Row._idtrabajador)
                    db.AddInParameter(xmd, "TIPO", DbType.String, Row._tipoanticipo)
                    db.AddInParameter(xmd, "PERIODO", DbType.String, Row.periodo)
                    db.AddInParameter(xmd, "TOTAL", DbType.Double, Row.montoTotal)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function CargarVacacionesAnticipo(ByVal obj As ETContratista) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CargarVacacionesAnticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarConceptoLiquidacion(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarConceptoLiquidacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDTRABAJADOR", DbType.String, obj._idtrabajador)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function InsertaLiquidacionTrabajador(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaLiquidacionTrabajador)
                    db.AddInParameter(xmd, "IDTRABAJADOR", DbType.Int32, Row._idtrabajador)
                    db.AddInParameter(xmd, "IDCONCEPTO", DbType.Int32, Row._idconcepto)
                    db.AddInParameter(xmd, "FECHACESE", DbType.DateTime, Row._fechacese)
                    db.AddInParameter(xmd, "MONTO", DbType.Double, Row.montoTotal)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function validaPeriodoVacaciones(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.validaPeriodoVacaciones)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@IDTRABAJADOR", DbType.Int32, obj._idtrabajador)
            db.AddInParameter(cmd, "@PERIODO", DbType.String, obj.periodo)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarOrden(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarOrden)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarCanteraAnticipo(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarCanteraAnticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarRetencionSolicitud(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarRetencionSolicitud)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarRetencionxValidar(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarRetencionxValidar)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ValidarRetencionSolicitud(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ValidarRetencionSolicitud)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@ID", DbType.Int32, obj.ID)
            db.AddInParameter(cmd, "@VALIDACION", DbType.Int32, obj._flgtrans)
            db.AddInParameter(cmd, "@MONTO", DbType.Decimal, obj.montoTotal)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function InsertaCanteraAnticipo(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.InsertaCanteraAnticipo)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "NUMSOLICITUD", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "CODCANTERA", DbType.String, Row._codcantera)
                    db.AddInParameter(xmd, "MONTO", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "ID_SUPERVISOR", DbType.Double, Row.IDSUPERVISOR)
                    db.ExecuteNonQuery(xmd, Trans)
                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function CargarCanteraAnticipo(ByVal obj As ETContratista) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CargarCanteraAnticipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, obj.NumSolicitud)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MantenimientoOtraFactura(ByVal Ls_Entrega As List(Of ETContratista)) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                For Each Row In Ls_Entrega

                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoOtraFactura)
                    db.AddInParameter(xmd, "@COD_PROV", DbType.String, Row._codprov)
                    db.AddInParameter(xmd, "@RUC", DbType.String, Row._ruc)
                    db.AddInParameter(xmd, "@TIPODOC", DbType.String, Row._tipodocumento)
                    db.AddInParameter(xmd, "@NUMERO", DbType.String, Row._documento)
                    db.AddInParameter(xmd, "@FECHA", DbType.DateTime, Row.Fecha)
                    db.AddInParameter(xmd, "@VALORVTA", DbType.Decimal, Row._valorvta)
                    db.AddInParameter(xmd, "@IGV", DbType.Decimal, Row._igv)
                    db.AddInParameter(xmd, "@VALORTOTAL", DbType.Decimal, Row._valor)
                    db.AddInParameter(xmd, "@FECHAREAL", DbType.DateTime, Row.FechaIngreso)
                    db.AddInParameter(xmd, "@TIPO", DbType.String, Row._tipo_fact)
                    db.ExecuteNonQuery(xmd, Trans)

                    'lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    'If lResult.Respuesta <> 0 Then Err.Raise(10)
                Next


                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarOtraFactura(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarOtraFactura)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@AYO", DbType.String, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.String, obj._mes)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function EliminaOtraFactura(ByVal obj As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        'If Ls_Entrega Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista


                Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.EliminaOtraFactura)
                db.AddInParameter(xmd, "@COD_PROV", DbType.String, obj._codprov)
                db.AddInParameter(xmd, "@RUC", DbType.String, obj._ruc)
                db.AddInParameter(xmd, "@TIPO", DbType.String, obj._tipodocumento)
                db.AddInParameter(xmd, "@NUMERO", DbType.String, obj._documento)
                db.ExecuteNonQuery(xmd, Trans)

                'lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function MantenimientoAlmacen(ByVal Rpt As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoAlmacen)

                db.AddInParameter(cmd, "TIPO", DbType.Int32, Rpt.TipoOperacion)
                db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "DESCRIPCION", DbType.String, Rpt._descripcion)
                db.AddInParameter(cmd, "CANTERA", DbType.String, Rpt._codcantera)
                db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt._usuario)
                db.AddInParameter(cmd, "FLGCONTRATISTA", DbType.Int32, Rpt._flgcontratista)
                db.ExecuteNonQuery(cmd, Trans)


                'If lResult.Respuesta <> 0 Then Err.Raise(10)

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarAlmacen() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarAlmacen)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarActivoContratista(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarActivoContratista)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@PLACA", DbType.String, obj._placa)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mant_ActivoContratista(ByVal Rpt As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Mant_ActivoContratista)

                db.AddInParameter(cmd, "CHECK", DbType.Int32, Rpt._check)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "PLACA", DbType.String, Rpt._placa)
                db.AddInParameter(cmd, "COD_PROV", DbType.String, Rpt._codprov)
                db.AddInParameter(cmd, "AYO", DbType.Int32, Rpt._ayo)
                db.AddInParameter(cmd, "MES", DbType.Int32, Rpt._mes)
                db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt._usuario)
                db.ExecuteNonQuery(cmd, Trans)


                'If lResult.Respuesta <> 0 Then Err.Raise(10)

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function VerificaActivoContratistaMes(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.VerificaActivoContratistaMes)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function AperturaActivoContratistaMes(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.AperturaActivoContratistaMes)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MantenimientoTipoMovimiento(ByVal Rpt As ETContratista) As ETContratista

        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETContratista

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoTipoMovimiento)

                db.AddInParameter(cmd, "TIPO", DbType.Int32, Rpt.TipoOperacion)
                db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "DESCRIPCION", DbType.String, Rpt._descripcion)
                db.AddInParameter(cmd, "MOVI", DbType.String, Rpt._movi)
                db.AddInParameter(cmd, "FLGTRANS", DbType.Int32, Rpt._flgtrans)
                db.AddInParameter(cmd, "IDREFERENCIA", DbType.Int32, Rpt._idreferencia)
                db.AddInParameter(cmd, "FLGVENTA", DbType.Int32, Rpt._flgventa)
                db.AddInParameter(cmd, "FLGOC", DbType.Int32, Rpt._flgOC)
                db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt._usuario)
                db.ExecuteNonQuery(cmd, Trans)


                'If lResult.Respuesta <> 0 Then Err.Raise(10)

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarTipoMovimiento() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarTipoMovimiento)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function Listar_TipoMovimiento() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_TipoMovimiento)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function TipoMovimientoConcepto(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.TipoMovimientoConcepto)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@ID", DbType.String, obj.ID)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function ListarCliente() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarCliente)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarMaquina() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarMaquina)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarEquipo() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarEquipo)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mant_MovimientoCombExplosivo(ByVal Rpt As ETContratista, ByVal dtDetalle As DataTable) As ETContratista
        Dim numdocori As String = ""
        Dim numdocdest As String = ""
        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETContratista
                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Mant_MovimientoCombExplosivo)
                db.AddInParameter(cmd, "TIPO", DbType.Int32, Rpt.Tipo)
                db.AddInParameter(cmd, "ID", DbType.Int32, Rpt.ID)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "IDTIPOMOV", DbType.Int32, Rpt._idtipomov)
                db.AddInParameter(cmd, "FECHA_EMISION", DbType.DateTime, Rpt.Fecha)
                db.AddInParameter(cmd, "TIPO_MATERIAL", DbType.String, Rpt._tipomaterial)
                db.AddInParameter(cmd, "NUM_REFERENCIA", DbType.String, Rpt._numorden)
                db.AddInParameter(cmd, "COD_ALMORI", DbType.String, Rpt._codalmori)
                db.AddInParameter(cmd, "COD_ALMDEST", DbType.String, Rpt._codalmdest)
                db.AddInParameter(cmd, "COD_CLI", DbType.String, Rpt._codcli)
                db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt._usuario)
                db.AddParameter(cmd, "NUMDOCORI", DbType.String, 10, ParameterDirection.InputOutput, True, 0, 0, "", DataRowVersion.Default, Rpt._numdocori)
                db.AddParameter(cmd, "NUMDOCDEST", DbType.String, 10, ParameterDirection.InputOutput, True, 0, 0, "", DataRowVersion.Default, Rpt._numdocdest)
                db.ExecuteNonQuery(cmd, Trans)
                numdocori = Convert.ToString(db.GetParameterValue(cmd, "NUMDOCORI"))
                numdocdest = Convert.ToString(db.GetParameterValue(cmd, "NUMDOCDEST"))
                'If lResult.Respuesta <> 0 Then Err.Raise(10)

                For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                    If dtDetalle.Rows(i)("CANTIDAD") > 0 Then
                        Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Mant_MovimientoCombExplosivoDet)
                        db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                        db.AddInParameter(xmd, "NUMDOCORI", DbType.String, numdocori)
                        db.AddInParameter(xmd, "NUMDOCDEST", DbType.String, numdocdest)
                        db.AddInParameter(xmd, "IDTIPOMOV", DbType.Int32, Rpt._idtipomov)
                        db.AddInParameter(xmd, "FECHA_EMISION", DbType.DateTime, Rpt.Fecha)
                        db.AddInParameter(xmd, "COD_PROD", DbType.String, dtDetalle.Rows(i)("COD_MATERIAL"))
                        db.AddInParameter(xmd, "DESCRIPCION", DbType.String, dtDetalle.Rows(i)("MATERIAL"))
                        db.AddInParameter(xmd, "CANTIDAD", DbType.Double, dtDetalle.Rows(i)("CANTIDAD"))
                        db.AddInParameter(xmd, "PRECIO", DbType.Double, dtDetalle.Rows(i)("VALOR"))
                        db.AddInParameter(xmd, "UM", DbType.String, dtDetalle.Rows(i)("UM"))
                        db.AddInParameter(xmd, "CANTERAORI", DbType.String, Rpt._codcanteraori)
                        db.AddInParameter(xmd, "CANTERADEST", DbType.String, Rpt._codcanteradest)
                        db.AddInParameter(xmd, "TIPO_EQUIPO", DbType.String, dtDetalle.Rows(i)("COD_TIPOEQUIPO"))
                        db.AddInParameter(xmd, "COD_EQUIPO", DbType.String, dtDetalle.Rows(i)("COD_EQUIPO"))
                        db.AddInParameter(xmd, "TIPOTRABAJO", DbType.String, dtDetalle.Rows(i)("COD_TIPOTRABAJO"))
                        db.AddInParameter(xmd, "TIPO_PERIODO", DbType.String, dtDetalle.Rows(i)("COD_TIPOTAREO"))
                        db.AddInParameter(xmd, "ENTRADAMAQ", DbType.Double, dtDetalle.Rows(i)("ENTRADA"))
                        db.AddInParameter(xmd, "SALIDAMAQ", DbType.Double, dtDetalle.Rows(i)("SALIDA"))
                        db.AddInParameter(xmd, "CANTIDADMAQ", DbType.Double, dtDetalle.Rows(i)("CANTMAQUINA"))
                        db.AddInParameter(xmd, "MOTIVO", DbType.String, "")
                        db.AddInParameter(xmd, "ITEM", DbType.Int32, dtDetalle.Rows(i)("ITEM"))
                        db.AddInParameter(xmd, "USUARIO", DbType.String, Rpt._usuario)
                        db.ExecuteNonQuery(xmd, Trans)
                    End If
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function
    Public Function ListarMovimientos(ByVal Rpt As ETContratista) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarMovimientos)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarProdOptima(ByVal Rpt As ETContratista) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarProdOptima)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            'db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MantProdOptima(ByVal Rpt As ETContratista) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.MantProdOptima)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@PLACA", DbType.String, Rpt._placa)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, Rpt._cod_prod)
            db.AddInParameter(cmd, "@TONXHORA", DbType.Double, Rpt._tonxhora)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CE_ListarOrden(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CE_ListarOrden)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try
    End Function
    Public Function CE_DetalleOrden(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CE_DetalleOrden)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMORDEN", DbType.String, obj._numorden)
            'db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            'db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CARGA_ENERGIA_ELECTRICA(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CARGA_ENERGIA_ELECTRICA)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@DIA", DbType.Int32, obj._dia)
            db.AddInParameter(cmd, "@CODEQUIPO", DbType.String, obj._codequipo)
            db.AddInParameter(cmd, "@KWH", DbType.Double, obj._toneladas)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            db.AddInParameter(cmd, "@HOJA", DbType.String, obj._descripcion)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function LISTA_ENERGIA_ELECTRICA(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.LISTA_ENERGIA_ELECTRICA)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CARGA_ENERGIA_ELECTRICA_MENSUAL(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CARGA_ENERGIA_ELECTRICA_MENSUAL)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CTR_INSERTA_CTAPAGKARDEX(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CTR_INSERTA_CTAPAGKARDEX)
        Dim lResult As ETMyLista = Nothing
        '@TIPO CHAR(2),
        '@DOCUMENTO VARCHAR(20),
        '@FECHAEMISION DATETIME,
        '@BANCO CHAR(2),
        '@NROASIGNADO CHAR(15),
        '@PLANILLA CHAR(10),
        '@MONEDA CHAR(3),
        '@IMPORTE DECIMAL(18,2),
        '@ITEM INT,
        '@RAZON VARCHAR(100),
        '@TCAMBIO DECIMAL(18,2),
        '@VOUCHER VARCHAR(10),
        '@FECHA_PROC DATETIME,
        '@IMPCONT DECIMAL(18,2),
        '@USUARIO VARCHAR(20)
        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROCESO", DbType.String, obj.COD_PROCESO)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@TIPO", DbType.String, obj.TIPO_ANT)
            db.AddInParameter(cmd, "@DOCUMENTO", DbType.String, obj.nrodoc)
            db.AddInParameter(cmd, "@FECHAEMISION", DbType.Date, obj.Fecha)
            db.AddInParameter(cmd, "@BANCO", DbType.String, obj.codbanco)
            db.AddInParameter(cmd, "@NROASIGNADO", DbType.String, obj.NROASIGNADO)
            db.AddInParameter(cmd, "@PLANILLA", DbType.String, obj.PLANILLA)
            db.AddInParameter(cmd, "@MONEDA", DbType.String, obj.moneda)
            db.AddInParameter(cmd, "@IMPORTE", DbType.String, obj._importe_NC)
            db.AddInParameter(cmd, "@ITEM", DbType.String, obj._item)
            db.AddInParameter(cmd, "@RAZON", DbType.String, obj._razon)
            db.AddInParameter(cmd, "@TCAMBIO", DbType.String, obj.TCAMBIO)
            db.AddInParameter(cmd, "@VOUCHER", DbType.String, obj.VOUCHER)
            db.AddInParameter(cmd, "@FECHA_PROC", DbType.Date, obj.FechaHora)
            db.AddInParameter(cmd, "@IMPCONT", DbType.String, obj._importe_NC)
            db.AddInParameter(cmd, "@TIPO_DOC_CAN", DbType.String, obj.TIPO_DOC_CAN)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj.Usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CTR_ANT_NUMERO_VOUCHER(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CTR_ANT_NUMERO_VOUCHER)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj.Anho)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CTR_ANT_GENERA_ASIENTO(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CTR_ANT_GENERA_ASIENTO)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj.Mes)
            db.AddInParameter(cmd, "@FECHA_PROC", DbType.Date, obj.Fecha)
            db.AddInParameter(cmd, "@VOUCHER", DbType.String, obj.VOUCHER)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj.Usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarMovimientoNumero(ByVal obj As ETContratista) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarMovimientoNumero)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMDOC", DbType.String, obj._numorden)

            Return db.ExecuteDataSet(cmd)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function BuscaTipoEquipo(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.BuscaTipoEquipo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@PLACA", DbType.String, obj._placa)
            'db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            'db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Reg_Alquiler_Maquina(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Reg_Alquiler_Maquina)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@OPE", DbType.Int32, obj.Operacion)
            db.AddInParameter(cmd, "@ID", DbType.Int32, obj.ID)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, obj._fecha1)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, obj._codprov)
            db.AddInParameter(cmd, "@RAZON", DbType.String, obj._razon)
            db.AddInParameter(cmd, "@NUMDOC", DbType.String, obj._numdocori)
            db.AddInParameter(cmd, "@HORA", DbType.String, obj.hora)
            db.AddInParameter(cmd, "@GALON", DbType.Decimal, obj._galon)
            db.AddInParameter(cmd, "@GALON_HORA", DbType.Decimal, obj._galon_hora)
            db.AddInParameter(cmd, "@CONTRATISTA", DbType.String, obj._contratista)
            db.AddInParameter(cmd, "@APROBADO", DbType.String, obj._aprobado)
            db.AddInParameter(cmd, "@RUTA", DbType.String, obj._ruta)
            db.AddInParameter(cmd, "@NOTA_CREDITO", DbType.String, obj._nota_credito)
            db.AddInParameter(cmd, "@IMPORTE_NC", DbType.Decimal, obj._importe_NC)
            db.AddInParameter(cmd, "@OBSERVACIONES", DbType.String, obj._observacion)
            db.AddInParameter(cmd, "@USUSARIO", DbType.String, obj._usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Reg_Alquiler_Maquina_Det(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Reg_Alquiler_Maquina_Det)
        Dim lResult As ETMyLista = Nothing
        
        Try
            db.AddInParameter(cmd, "@ID_CAB", DbType.Int32, obj._id)
            db.AddInParameter(cmd, "@ITEM", DbType.Int32, obj._item)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, obj._cantera)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, obj._fecha1)
            db.AddInParameter(cmd, "@HORO_INI", DbType.String, obj._horo_ini)
            db.AddInParameter(cmd, "@HORO_FIN", DbType.String, obj._horo_fin)
            db.AddInParameter(cmd, "@HORA", DbType.String, obj.hora)
            db.AddInParameter(cmd, "@GALON", DbType.Decimal, obj._galon)
            db.AddInParameter(cmd, "@GALON_HORA", DbType.Decimal, obj._galon_hora)
            db.AddInParameter(cmd, "@LABOR", DbType.String, obj._labor)
            db.AddInParameter(cmd, "@ACTIVIDAD", DbType.String, obj._actividad)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Carga_Movimiento(ByVal Rpt As ETContratista, ByVal dtDetalle As DataTable) As ETContratista
        Dim numdocori As String = ""
        Dim numdocdest As String = ""
        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETContratista
                For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                    'If dtDetalle.Rows(i)("CANTIDAD") > 0 Then
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Carga_Movimiento)
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "AYO", DbType.Int32, Rpt._ayo)
                    db.AddInParameter(xmd, "MES", DbType.Int32, Rpt._mes)
                    'db.AddInParameter(xmd, "IDTIPOMOV", DbType.Int32, Rpt._idtipomov)
                    db.AddInParameter(xmd, "FECHA_EMISION", DbType.DateTime, dtDetalle.Rows(i)("FECHA"))
                    db.AddInParameter(xmd, "TIPO_MATERIAL", DbType.String, Rpt._tipomaterial)
                    db.AddInParameter(xmd, "COD_ALMORI", DbType.String, Rpt._codalmori)
                    db.AddInParameter(xmd, "COD_CLI", DbType.String, Rpt._codcli)
                    db.AddInParameter(xmd, "COD_PROD", DbType.String, dtDetalle.Rows(i)("COD_MATERIAL"))
                    db.AddInParameter(xmd, "DESCRIPCION", DbType.String, dtDetalle.Rows(i)("MATERIAL"))
                    db.AddInParameter(xmd, "CANTIDAD", DbType.Double, dtDetalle.Rows(i)("CANTIDAD"))
                    db.AddInParameter(xmd, "PRECIO", DbType.Double, dtDetalle.Rows(i)("VALOR"))
                    db.AddInParameter(xmd, "UM", DbType.String, dtDetalle.Rows(i)("UM"))
                    db.AddInParameter(xmd, "CANTERAORI", DbType.String, Rpt._codcanteraori)
                    'db.AddInParameter(xmd, "CANTERADEST", DbType.String, Rpt._codcanteradest)
                    db.AddInParameter(xmd, "TIPO_EQUIPO", DbType.String, dtDetalle.Rows(i)("COD_TIPOEQUIPO"))
                    db.AddInParameter(xmd, "COD_EQUIPO", DbType.String, dtDetalle.Rows(i)("COD_EQUIPO"))
                    db.AddInParameter(xmd, "TIPOTRABAJO", DbType.String, dtDetalle.Rows(i)("COD_TIPOTRABAJO"))
                    db.AddInParameter(xmd, "TIPO_PERIODO", DbType.String, dtDetalle.Rows(i)("COD_TIPOTAREO"))
                    db.AddInParameter(xmd, "ENTRADAMAQ", DbType.Double, dtDetalle.Rows(i)("ENTRADA"))
                    db.AddInParameter(xmd, "SALIDAMAQ", DbType.Double, dtDetalle.Rows(i)("SALIDA"))
                    db.AddInParameter(xmd, "CANTIDADMAQ", DbType.Double, dtDetalle.Rows(i)("CANTMAQUINA"))
                    db.AddInParameter(xmd, "MOTIVO", DbType.String, dtDetalle.Rows(i)("MOTIVO"))
                    db.AddInParameter(xmd, "USUARIO", DbType.String, Rpt._usuario)
                    db.AddInParameter(xmd, "PERIODO", DbType.Int32, Rpt._quincena)
                    db.ExecuteNonQuery(xmd, Trans)
                    'End If
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ValidaCarga(ByVal obj As ETContratista) As String

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ValidaCarga)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@COD_CLI", DbType.String, obj._codcli)
            db.AddInParameter(cmd, "@COD_ALMORI ", DbType.String, obj._codalmori)
            db.AddInParameter(cmd, "@COD_EQUIPO", DbType.String, obj._codequipo)
            db.AddInParameter(cmd, "@TIPO_CARGA", DbType.String, obj._tipomaterial)
            db.AddInParameter(cmd, "@PERIODO", DbType.Int32, obj._quincena)
            Return db.ExecuteDataSet(cmd).Tables(0).Rows(0)(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Elimina_Carga_Movimiento(ByVal obj As ETContratista) As ETContratista
        Dim numdocori As String = ""
        Dim numdocdest As String = ""
        Dim lResult As ETContratista = Nothing
        If obj Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETContratista
                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Elimina_Carga_Movimiento)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
                db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
                db.AddInParameter(cmd, "@COD_CLI", DbType.String, obj._codcli)
                db.AddInParameter(cmd, "@COD_ALMORI ", DbType.String, obj._codalmori)
                db.AddInParameter(cmd, "@COD_EQUIPO", DbType.String, obj._codequipo)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, obj._usuario)
                db.AddInParameter(cmd, "@TIPO_CARGA", DbType.String, obj._tipomaterial)
                db.AddInParameter(cmd, "@PERIODO", DbType.String, obj._quincena)
                db.ExecuteNonQuery(cmd, Trans)
                'If lResult.Respuesta <> 0 Then Err.Raise(10)

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ListarCargas(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarCargas)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CTR_ListarCombustible(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CTR_ListarCombustible)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@IDCAB", DbType.String, Rpt.ID)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "@CODCLI", DbType.String, Rpt._codcli)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, Rpt._codcantera)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function LISTA_CE_FACT_COMBUSTIBLE_CAB(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.LISTA_CE_FACT_COMBUSTIBLE_CAB)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CTR_CE_FACT_COMBUSTIBLE_CAB(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CTR_CE_FACT_COMBUSTIBLE_CAB)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@OPE", DbType.Int32, Rpt.Operacion)
            db.AddInParameter(cmd, "@ID", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "@COD_CLI", DbType.String, Rpt._codcli)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, Rpt._codcantera)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)
            db.AddInParameter(cmd, "@MONEDA", DbType.String, Rpt.moneda)
            db.AddInParameter(cmd, "@TOTAL", DbType.Decimal, Rpt.Total)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CTR_CE_FACT_COMBUSTIBLE_DET(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CTR_CE_FACT_COMBUSTIBLE_DET)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@IDDET", DbType.Int64, Rpt._idconcepto)
            db.AddInParameter(cmd, "@IDCAB", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, Rpt._codprod)
            db.AddInParameter(cmd, "@CANTIDAD", DbType.Decimal, Rpt.Cantidad)
            db.AddInParameter(cmd, "@PRECIO", DbType.Decimal, Rpt._precio)
            db.AddInParameter(cmd, "@TOTAL", DbType.Decimal, Rpt.Total)
            db.AddInParameter(cmd, "@ID_MOVDET", DbType.Int64, Rpt._idtipomov)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarEquipoCantera(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarEquipoCantera)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt._mes)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function InsertaEquipoCantera(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.InsertaEquipoCantera)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt._mes)
            db.AddInParameter(cmd, "@COD_EQUIPO", DbType.String, Rpt._codequipo)
            db.AddInParameter(cmd, "@CODCANTERA", DbType.String, Rpt._codcantera)
            db.AddInParameter(cmd, "@ESTADO", DbType.String, Rpt.Estado)
            db.AddInParameter(cmd, "@MODELO", DbType.String, Rpt._modelo)
            db.AddInParameter(cmd, "@SERIE", DbType.String, Rpt._serie)
            db.AddInParameter(cmd, "@CONTRATISTA", DbType.String, Rpt._contratista)
            db.AddInParameter(cmd, "@RESPONSABLE", DbType.String, Rpt._responsable)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt._usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function EliminaEquipoCantera(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.EliminaEquipoCantera)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt._mes)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarFacturaAlquiler(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarFacturaAlquiler)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarFacturaAlquiler_ID(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarFacturaAlquiler_ID)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@ID", DbType.Int32, Rpt.ID)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function user_Aprueba_Alquiler(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.user_Aprueba_Alquiler)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarRegistroAlquiler(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarRegistroAlquiler)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarRegistroAlquiler_Det(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarRegistroAlquiler_Det)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@ID", DbType.Int32, Rpt.ID)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Kardex(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Kardex)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt._mes)
            db.AddInParameter(cmd, "@CODALMACEN", DbType.String, Rpt._codalmori)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Existencias(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Existencias)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt._mes)
            db.AddInParameter(cmd, "@TIPOMATERIAL", DbType.String, Rpt._tipomaterial)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function ValidaFechasCarga(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ValidaFechasCarga)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, obj._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, obj._mes)
            db.AddInParameter(cmd, "@PERIODO", DbType.String, obj._quincena)
            db.AddInParameter(cmd, "@TIPOMATERIAL", DbType.String, obj._tipomaterial)
            db.AddInParameter(cmd, "@CODCONTRATISTA", DbType.String, obj._codcli)
            db.AddInParameter(cmd, "@CODALMACEN", DbType.String, obj._codalmori)
            db.AddInParameter(cmd, "@COD_EQUIPO", DbType.String, obj._codequipo)
            Return db.ExecuteDataSet(cmd).Tables(0)
        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function MaqPesada(ByVal Rpt As ETContratista) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.MaqPesada)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt._ayo)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt._mes)

            Return db.ExecuteDataSet(cmd)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarDocumentoAprobar(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarDocumentoAprobar)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)
            db.AddInParameter(cmd, "@COD_CLI", DbType.String, Rpt._codcli)
            db.AddInParameter(cmd, "@TIPO_COMPROB", DbType.String, Rpt._tipodocumento)
            db.AddInParameter(cmd, "@NUMDOC", DbType.String, Rpt._documento)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarClientes() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarClientes)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarClientesPareto(ByVal _parameter As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListarClientesPareto)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD", DbType.Int32, _parameter)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function


    Public Function ApruebaDocumento(ByVal Rpt As ETContratista, ByVal dtDetalle As DataTable) As ETContratista
        Dim numdocori As String = ""
        Dim numdocdest As String = ""
        Dim lResult As ETContratista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETContratista
                For i As Int32 = 0 To dtDetalle.Rows.Count - 1
                    'If dtDetalle.Rows(i)("CANTIDAD") > 0 Then
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ApruebaDocumento)
                    db.AddInParameter(xmd, "CHECK ", DbType.Int32, IIf(dtDetalle.Rows(i)("ACTION").ToString = "True", 1, 0))
                    db.AddInParameter(xmd, "CIA", DbType.String, Companhia)
                    db.AddInParameter(xmd, "COD_CLI", DbType.String, dtDetalle.Rows(i)("COD_CLI"))
                    db.AddInParameter(xmd, "TIPO_COMPROB", DbType.String, dtDetalle.Rows(i)("TIPO_COMPROB"))
                    db.AddInParameter(xmd, "NUMDOC", DbType.String, dtDetalle.Rows(i)("NUMDOC"))
                    db.AddInParameter(xmd, "USUARIO", DbType.String, Rpt.Usuario)
                    db.ExecuteNonQuery(xmd, Trans)
                    'End If
                Next

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using

        Return lResult

    End Function

    Public Function ValidaProduto(ByVal codprod As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ValidaProduto)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, codprod)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ConsultaContratista(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CTR_CONSULTA)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function RptVacaciones_CTR(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.RptVacaciones_CTR)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function RptExMedico_CTR(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.RptExMedico_CTR)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function RptIgvRenta_CTR(ByVal Rpt As ETContratista) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.RptIgvRenta_CTR)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@AYO", DbType.Int32, Rpt.Anho)
            db.AddInParameter(cmd, "@MES", DbType.Int32, Rpt._mes)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            Return db.ExecuteDataSet(cmd)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function RptLiquidaciones_CTR(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.RptLiquidaciones_CTR)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt._fecha1)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt._fecha2)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_Camiones(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_Camiones)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_Prov_Codigo(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_Prov_Codigo)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_MantCamion(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_MantCamion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, Rpt.Tipo)
            db.AddInParameter(cmd, "@ID", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@PLACA", DbType.String, Rpt._placa)
            db.AddInParameter(cmd, "@DESCRIPCION", DbType.String, Rpt._descripcion)
            db.AddInParameter(cmd, "@MARCA", DbType.String, Rpt._marca)
            db.AddInParameter(cmd, "@MODELO", DbType.String, Rpt._modelo)
            db.AddInParameter(cmd, "@AYOFABRICACION", DbType.Int32, Rpt._ayo)
            db.AddInParameter(cmd, "@PESO", DbType.Double, Rpt._peso)
            db.AddInParameter(cmd, "@CONFIGVEG", DbType.String, Rpt._configveh)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_MantDisponibilidad(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_MantDisponibilidad)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@TIPO", DbType.String, Rpt.Tipo)
            'db.AddInParameter(cmd, "@ID", DbType.String, Rpt.ID)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDCAMION", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@FLGACTIVO", DbType.Int32, Rpt._check)
            db.AddInParameter(cmd, "@FLGACTIVO2", DbType.Int32, Rpt._check2)
            db.AddInParameter(cmd, "@FLGACTIVO3", DbType.Int32, Rpt._check3)
            db.AddInParameter(cmd, "@OBSERVACION", DbType.String, Rpt._observacion)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_Disponibilidad(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_Disponibilidad)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_CamionDisponible(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_CamionDisponible)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@NROVIAJE", DbType.Int32, Rpt.NroViaje)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_Programacion(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_Programacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@NROVIAJE", DbType.Int32, Rpt.NroViaje)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_ConfigVehicular() As List(Of ETConfigVehicular)

        Dim lista As New List(Of ETConfigVehicular)
        Dim item As ETConfigVehicular = Nothing

        Try
            Dim db As Database = DatabaseFactory.CreateDatabase()
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_ConfigVehicular)

            db.AddInParameter(cmd, "@CODCIA", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    item = New ETConfigVehicular

                    If dr("ID") IsNot DBNull.Value Then
                        item.ID = Convert.ToInt32(dr("ID"))
                    End If

                    If dr("CONFIGVEH") IsNot DBNull.Value Then
                        item.ConfigVeh = Convert.ToString(dr("CONFIGVEH"))
                    End If

                    If dr("CARGA_UTIL") IsNot DBNull.Value Then
                        item.CargaUtil = Convert.ToDecimal(dr("CARGA_UTIL"))
                    End If

                    lista.Add(item)
                End While

            End Using

        Catch Err As Exception
            Throw New Exception(Err.Message)
        End Try

        Return lista

    End Function

    Public Function Elimina_Programacion(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Elimina_Programacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.Int32, Rpt.Tipo)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NROVIAJE", DbType.Int32, Rpt.NroViaje)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CargaUnacem(ByVal dtDatos As DataTable, ByVal usuario As String, ByVal ayo As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Dim lResult As ETMyLista = Nothing


            Dim dtResult As New DataTable
            Try
                For i As Int32 = 0 To dtDatos.Rows.Count - 1
                    Dim fecha_proceso As Date = IIf(dtDatos.Rows(i)("FECHA_INGRESO_UNACEM").ToString.Trim = "", "01/01/1990", dtDatos.Rows(i)("FECHA_INGRESO_UNACEM").ToString.Trim)
                    Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CargaUnacem)
                    cmd.CommandTimeout = 0
                    'objEntidad = New ETContratista
                    If dtDatos.Rows(i)("FECHA_INGRESO_UNACEM").ToString <> "" And dtDatos.Rows(i)("FECHA_SALIDA_CANTERA").ToString <> "" And Year(fecha_proceso) = ayo Then
                        db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                        db.AddInParameter(cmd, "@PLACA", DbType.String, dtDatos.Rows(i)("PLACA_TRACTO").ToString.Trim)
                        db.AddInParameter(cmd, "@CHOFER", DbType.String, dtDatos.Rows(i)("NOMBRES_CONDUCTOR").ToString.Trim)
                        db.AddInParameter(cmd, "@SERIE_TRANSP", DbType.String, dtDatos.Rows(i)("SERIE_GUIA_TRANSPORTISTA").ToString.Trim)
                        db.AddInParameter(cmd, "@NUM_TRANSP", DbType.String, dtDatos.Rows(i)("NUMERO_TRANSPORTISTA").ToString.Trim)
                        db.AddInParameter(cmd, "@SERIE_COMACSA", DbType.String, dtDatos.Rows(i)("SERIE_GUIA_COMACSA").ToString.Trim)
                        db.AddInParameter(cmd, "@NUM_COMACSA", DbType.String, dtDatos.Rows(i)("NUMERO_GUIA_COMACSA").ToString.Trim)
                        db.AddInParameter(cmd, "@COD_TRANSP", DbType.String, dtDatos.Rows(i)("CODIGO_TRANSPORTISTA").ToString.Trim)
                        db.AddInParameter(cmd, "@PLACA_2", DbType.String, dtDatos.Rows(i)("PLACA_CARRETA").ToString.Trim)
                        db.AddInParameter(cmd, "@PESO_1", DbType.Decimal, dtDatos.Rows(i)("PESO_BRUTO").ToString.Trim)
                        db.AddInParameter(cmd, "@FECHAHORA1", DbType.DateTime, dtDatos.Rows(i)("FECHA_INGRESO_UNACEM"))
                        db.AddInParameter(cmd, "@PESO_2", DbType.Decimal, dtDatos.Rows(i)("PESO_TARA").ToString.Trim)
                        db.AddInParameter(cmd, "@FECHAHORA2", DbType.DateTime, dtDatos.Rows(i)("FECHA_INGRESO_UNACEM"))
                        db.AddInParameter(cmd, "@NETO", DbType.Decimal, dtDatos.Rows(i)("PESO_NETO").ToString.Trim)
                        db.AddInParameter(cmd, "@FECHASALCANTERA", DbType.DateTime, dtDatos.Rows(i)("FECHA_SALIDA_CANTERA"))
                        db.AddInParameter(cmd, "@COD_PROD", DbType.String, dtDatos.Rows(i)("CODIGO_MINERAL").ToString.Trim)
                        db.AddInParameter(cmd, "@USUARIO", DbType.String, usuario)
                        db.AddInParameter(cmd, "@DNI", DbType.String, dtDatos.Rows(i)("DNI_CONDUCTOR").ToString.Trim)
                        db.AddInParameter(cmd, "@DOC_FISICO", DbType.String, dtDatos.Rows(i)("DOCUMENTOS_ENTREGADOS_FISICO").ToString.Trim)
                        db.AddInParameter(cmd, "@CVPM", DbType.String, dtDatos.Rows(i)("N_CVPM").ToString.Trim)
                        dtResult = db.ExecuteDataSet(cmd).Tables(0)
                        If dtResult.Rows.Count > 0 Then
                            If dtResult.Rows(0)(0).ToString.Trim.ToUpper <> "OK" Then
                                MsgBox(dtResult.Rows(0)(0).ToString.Trim.ToUpper, MsgBoxStyle.Information, MsgComacsa)
                            End If
                        End If
                    End If

                Next
                Trans.Commit()
                Conexion.Close()
                Return dtResult

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function CargaBilletesPrev(ByVal dtDatos As DataTable, ByVal usuario As String, ByVal ayo As Integer, ByVal cod_alm As String, ByVal transferencia As Integer, ByVal cod_alm_ori As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Dim lResult As ETMyLista = Nothing


            Dim dtResult As New DataTable
            Try
                For i As Int32 = 0 To dtDatos.Rows.Count - 1
                    Dim fecha_proceso As Date = IIf(dtDatos.Rows(i)("FECHA").ToString.Trim = "", "01/01/1990", dtDatos.Rows(i)("FECHA").ToString.Trim)
                    Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.CargaBilletesPrev)
                    cmd.CommandTimeout = 0
                    'objEntidad = New ETContratista
                    'If dtDatos.Rows(i)("FECHA_INGRESO_UNACEM").ToString <> "" And dtDatos.Rows(i)("FECHA_SALIDA_CANTERA").ToString <> "" And Year(fecha_proceso) = ayo Then
                    If dtDatos.Rows(i)("ITEM").ToString.Trim <> "" Then
                        db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                        db.AddInParameter(cmd, "@PLACA", DbType.String, dtDatos.Rows(i)("PLACA_TRACTO").ToString.Trim)
                        db.AddInParameter(cmd, "@CHOFER", DbType.String, dtDatos.Rows(i)("NOMBRES_CONDUCTOR").ToString.Trim)
                        db.AddInParameter(cmd, "@SERIE_TRANSP", DbType.String, dtDatos.Rows(i)("SERIE_GUIA_TRANSPORTISTA").ToString.Trim)
                        db.AddInParameter(cmd, "@NUM_TRANSP", DbType.String, dtDatos.Rows(i)("NUMERO_TRANSPORTISTA").ToString.Trim)
                        db.AddInParameter(cmd, "@SERIE_COMACSA", DbType.String, dtDatos.Rows(i)("SERIE_GUIA_COMACSA_PROVEEDOR").ToString.Trim)
                        db.AddInParameter(cmd, "@NUM_COMACSA", DbType.String, dtDatos.Rows(i)("NUMERO_GUIA_COMACSA_PROVEEDOR").ToString.Trim)
                        db.AddInParameter(cmd, "@COD_TRANSP", DbType.String, dtDatos.Rows(i)("CODIGO_TRANSPORTISTA").ToString.Trim)
                        db.AddInParameter(cmd, "@PLACA_2", DbType.String, dtDatos.Rows(i)("PLACA_CARRETA").ToString.Trim)
                        db.AddInParameter(cmd, "@PESO_1", DbType.Decimal, dtDatos.Rows(i)("PESO_BRUTO").ToString.Trim)
                        db.AddInParameter(cmd, "@FECHAHORA1", DbType.DateTime, dtDatos.Rows(i)("FECHA"))
                        db.AddInParameter(cmd, "@PESO_2", DbType.Decimal, dtDatos.Rows(i)("PESO_TARA").ToString.Trim)
                        db.AddInParameter(cmd, "@FECHAHORA2", DbType.DateTime, dtDatos.Rows(i)("FECHA"))
                        db.AddInParameter(cmd, "@NETO", DbType.Decimal, dtDatos.Rows(i)("PESO_NETO").ToString.Trim)
                        db.AddInParameter(cmd, "@FECHASALCANTERA", DbType.DateTime, dtDatos.Rows(i)("FECHA_SALIDA_CANTERA"))
                        db.AddInParameter(cmd, "@COD_CANTERA", DbType.String, dtDatos.Rows(i)("CODIGO_CANTERA").ToString.Trim)
                        db.AddInParameter(cmd, "@COD_RUMA", DbType.String, dtDatos.Rows(i)("CODIGO_RUMA").ToString.Trim)
                        db.AddInParameter(cmd, "@COD_PROD", DbType.String, dtDatos.Rows(i)("CODIGO_MINERAL").ToString.Trim)
                        db.AddInParameter(cmd, "@USUARIO", DbType.String, usuario)
                        db.AddInParameter(cmd, "@DNI", DbType.String, dtDatos.Rows(i)("DNI_CONDUCTOR").ToString.Trim)
                        db.AddInParameter(cmd, "@DOC_FISICO", DbType.String, "")
                        db.AddInParameter(cmd, "@CVPM", DbType.String, dtDatos.Rows(i)("N_CVPM").ToString.Trim)
                        db.AddInParameter(cmd, "@CONFVEHI", DbType.String, dtDatos.Rows(i)("CONF_VEHICULAR").ToString.Trim)
                        db.AddInParameter(cmd, "@PESOMAX", DbType.String, dtDatos.Rows(i)("PESO_MAX").ToString.Trim)
                        db.AddInParameter(cmd, "@COD_ALM", DbType.String, cod_alm.ToString.Trim)

                        db.AddInParameter(cmd, "@TRANSFERENCIA", DbType.String, transferencia.ToString.Trim)
                        If cod_alm_ori Is Nothing Then cod_alm_ori = "00"
                        db.AddInParameter(cmd, "@COD_ALM_DEST", DbType.String, cod_alm_ori.ToString.Trim)
                        db.AddInParameter(cmd, "@COD_RUMA_DEST", DbType.String, dtDatos.Rows(i)("RUMA_ORIGEN").ToString.Trim)
                        'db.AddInParameter(cmd, "@FECHA_SALIDA_CANTERA", DbType.String, dtDatos.Rows(i)("N_CVPM").ToString.Trim)

                        dtResult = db.ExecuteDataSet(cmd).Tables(0)
                        If dtResult.Rows.Count > 0 Then
                            If dtResult.Rows(0)(0).ToString.Trim.ToUpper <> "OK" Then
                                MsgBox(dtResult.Rows(0)(0).ToString.Trim.ToUpper, MsgBoxStyle.Information, MsgComacsa)
                            End If
                        End If
                        'End If
                    End If
                Next
                Trans.Commit()
                Conexion.Close()
                Return dtResult

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function ListaCargaUnacem(ByVal obj As ETContratista) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListaCargaUnacem)
            Dim lResult As ETMyLista = Nothing


            Dim dtResult As New DataSet
            Try
                db.AddInParameter(cmd, "@AYO", DbType.Int32, obj.Anho)
                dtResult = db.ExecuteDataSet(cmd)

                Trans.Commit()
                Conexion.Close()
                Return dtResult

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function ListaCargaBilletePrev(ByVal obj As ETContratista) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ListaCargaBilletePrev)
            Dim lResult As ETMyLista = Nothing


            Dim dtResult As New DataSet
            Try
                db.AddInParameter(cmd, "@AYO", DbType.Int32, obj.Anho)
                db.AddInParameter(cmd, "@COD_ALM", DbType.String, obj.COD_ALM)
                db.AddInParameter(cmd, "@MES", DbType.Int32, obj.Mes)
                dtResult = db.ExecuteDataSet(cmd)

                Trans.Commit()
                Conexion.Close()
                Return dtResult

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function ValidaCargaUnacem(ByVal obj As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ValidaCargaUnacem)
            Dim lResult As ETMyLista = Nothing


            Dim dtResult As New DataTable
            Try
                db.AddInParameter(cmd, "@FECHA", DbType.DateTime, obj.Fecha)
                dtResult = db.ExecuteDataSet(cmd).Tables(0)

                Trans.Commit()
                Conexion.Close()
                Return dtResult

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
    End Function

    Public Function Registra_Programacion(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Registra_Programacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NROVIAJE", DbType.Int32, Rpt.NroViaje)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@COD_PROGRAMACION", DbType.Int32, Rpt._codprog)
            db.AddInParameter(cmd, "@NUMPEDIDO", DbType.String, Rpt._numorden)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@PLACA", DbType.String, Rpt._placa)
            db.AddInParameter(cmd, "@CANTIDAD", DbType.Double, Rpt._toneladas)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "@ORDEN", DbType.Int32, Rpt._orden)
            db.AddInParameter(cmd, "@COD_PROD", DbType.String, Rpt._codprod)
            db.AddInParameter(cmd, "@PRODUCTO", DbType.String, Rpt._descripcion)
            db.AddInParameter(cmd, "@ITEM", DbType.Int32, Rpt._item)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_ProgramacionCamion(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_ProgramacionCamion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@NROVIAJE", DbType.Int32, Rpt.NroViaje)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_ConsultaProgramacion(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_ConsultaProgramacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            db.AddInParameter(cmd, "@NROVIAJE", DbType.Int32, Rpt.NroViaje)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_PRO_Prod_Programacion(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Listar_PRO_Prod_Programacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMPEDIDO", DbType.String, Rpt._numorden)
            db.AddInParameter(cmd, "@COD_PROGRAMACION", DbType.Int32, Rpt._codprog)
            db.AddInParameter(cmd, "@NROVIAJE", DbType.Int32, Rpt.NroViaje)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Consulta_GuiaProgramacion(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Consulta_GuiaProgramacion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Consulta_GuiaProgramacion2(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Consulta_GuiaProgramacion2)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Consulta_GuiaProgramacionV2(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Consulta_GuiaProgramacionV2)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@COD_PROV", DbType.String, Rpt._codprov)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Reprogramacion_Pedido(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Reprogramacion_Pedido)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDPROGRAMACION", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@PLACA", DbType.String, Rpt._placa)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Actualiza_Placa_Prog(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Actualiza_Placa_Prog)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@IDPROGRAMACION", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@PLACA", DbType.String, Rpt._placa)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function llenar_Incidencia(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.llenar_Incidencia)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function llenar_Concepto(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.llenar_Concepto)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Registra_Incidencia(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Registra_Incidencia)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDPROGRAMACION", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@FECHA", DbType.DateTime, Rpt.Fecha)
            db.AddInParameter(cmd, "@HORA", DbType.String, Rpt.hora)
            db.AddInParameter(cmd, "@IDCONCEPTO", DbType.Int32, Rpt._idconcepto)
            db.AddInParameter(cmd, "@IDESTADO", DbType.Int32, Rpt.idEstado)
            db.AddInParameter(cmd, "@OBSERVACION", DbType.String, Rpt._observacion)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Consulta_Incidencia(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Consulta_Incidencia)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDPROGRAMACION", DbType.Int32, Rpt.ID)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Elimina_Incidencia(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Elimina_Incidencia)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@IDINCIDENCIA", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mant_Concepto_Prog(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Mant_Concepto_Prog)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.String, Rpt.TipoOperacion)
            db.AddInParameter(cmd, "@IDCONCEPTO", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@CONCEPTO", DbType.String, Rpt._descripcion)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function Mant_Incidencia_Prog(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.Mant_Incidencia_Prog)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.String, Rpt.TipoOperacion)
            db.AddInParameter(cmd, "@IDINCIDENCIA", DbType.Int32, Rpt.ID)
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@INCIDENCIA", DbType.String, Rpt._descripcion)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ConsultarConsumoRecursos(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ConsultarConsumoRecursos)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@opcion", DbType.String, Rpt._tipopago)
            db.AddInParameter(cmd, "@idConsumoRecursos", DbType.String, Rpt.cadena)
            db.AddInParameter(cmd, "@año", DbType.String, Rpt.YearStr)
            db.AddInParameter(cmd, "@descripcion", DbType.String, Rpt._descripcion)
            db.AddInParameter(cmd, "@tipoConsumo", DbType.String, Rpt.ANEXO3)
            db.AddInParameter(cmd, "@Enero", DbType.Double, Rpt.enero)
            db.AddInParameter(cmd, "@Febrero", DbType.Double, Rpt.febrero)
            db.AddInParameter(cmd, "@Marzo", DbType.Double, Rpt.marzo)
            db.AddInParameter(cmd, "@Abril", DbType.Double, Rpt.abril)
            db.AddInParameter(cmd, "@Mayo", DbType.Double, Rpt.mayo)
            db.AddInParameter(cmd, "@Junio", DbType.Double, Rpt.junio)
            db.AddInParameter(cmd, "@Julio", DbType.Double, Rpt.julio)
            db.AddInParameter(cmd, "@Agosto", DbType.Double, Rpt.agosto)
            db.AddInParameter(cmd, "@Septiembre", DbType.Double, Rpt.septiembre)
            db.AddInParameter(cmd, "@Octubre", DbType.Double, Rpt.octubre)
            db.AddInParameter(cmd, "@Noviembre", DbType.Double, Rpt.noviembre)
            db.AddInParameter(cmd, "@Diciembre", DbType.Double, Rpt.diciembre)
            db.AddInParameter(cmd, "@usuario", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "@fecha", DbType.Date, Rpt.Fecha)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
    Public Function ConsultarLecturaDrone(ByVal Rpt As ETContratista) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Contratista.ConsultarLecturaDrone)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@opcion", DbType.String, Rpt._tipopago)
            db.AddInParameter(cmd, "@codRuma", DbType.String, Rpt.cadena)
            db.AddInParameter(cmd, "@periodo", DbType.String, Rpt.YearStr)
            db.AddInParameter(cmd, "@Enero", DbType.Double, Rpt.enero)
            db.AddInParameter(cmd, "@Febrero", DbType.Double, Rpt.febrero)
            db.AddInParameter(cmd, "@Marzo", DbType.Double, Rpt.marzo)
            db.AddInParameter(cmd, "@Abril", DbType.Double, Rpt.abril)
            db.AddInParameter(cmd, "@Mayo", DbType.Double, Rpt.mayo)
            db.AddInParameter(cmd, "@Junio", DbType.Double, Rpt.junio)
            db.AddInParameter(cmd, "@Julio", DbType.Double, Rpt.julio)
            db.AddInParameter(cmd, "@Agosto", DbType.Double, Rpt.agosto)
            db.AddInParameter(cmd, "@Septiembre", DbType.Double, Rpt.septiembre)
            db.AddInParameter(cmd, "@Octubre", DbType.Double, Rpt.octubre)
            db.AddInParameter(cmd, "@Noviembre", DbType.Double, Rpt.noviembre)
            db.AddInParameter(cmd, "@Diciembre", DbType.Double, Rpt.diciembre)
            db.AddInParameter(cmd, "@usuario", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "@fecha", DbType.Date, Rpt.Fecha)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function
End Class
