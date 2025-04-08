Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAFacturaTelefonica
    Public Function Listar(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spFactTelefonia_Listar)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, pFactElect.CodCia)

            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt
    End Function
    Public Function Obtener(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spFactTelefonia_Obtener)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, pFactElect.CodCia)
            db.AddInParameter(cmd, "ID", DbType.Int32, pFactElect.ID)

            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt
    End Function
    Public Function Mantenimiento(ByVal pFactTelefonica As ETFacturaTelefonica, ByVal pOpcion As Integer) As ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spFactTelefonia_Mantenimiento)

        Dim trama As String = ""
        Dim Resultado As New ETResultado
        Resultado.Realizo = False

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "CodCia", DbType.String, pFactTelefonica.CodCia)
                db.AddInParameter(cmd, "ID", DbType.Int32, pFactTelefonica.ID)
                db.AddInParameter(cmd, "CodProv", DbType.String, pFactTelefonica.CodProv)
                db.AddInParameter(cmd, "TipoDoc", DbType.String, pFactTelefonica.TipoDoc)
                db.AddInParameter(cmd, "numdoc", DbType.String, pFactTelefonica.NroDoc)
                db.AddInParameter(cmd, "anio", DbType.Int32, pFactTelefonica.Anio)
                db.AddInParameter(cmd, "mes", DbType.Int32, pFactTelefonica.Mes)
                db.AddInParameter(cmd, "grupo", DbType.String, pFactTelefonica.Grupo)
                db.AddInParameter(cmd, "placod", DbType.String, pFactTelefonica.PlaCod)
                db.AddInParameter(cmd, "Usuario", DbType.String, pFactTelefonica.Usuario)
                db.AddInParameter(cmd, "Operacion", DbType.Int32, pOpcion)

                trama = Convert.ToString(db.ExecuteScalar(cmd, Trans))

                Dim a() As String = trama.Split("|")

                If a(0) = "1" Then
                    Resultado.Realizo = True
                    Resultado.Valor = Convert.ToInt32(a(2))
                    Trans.Commit()
                Else
                    Trans.Rollback()
                End If

                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using

        Return Resultado
    End Function

    Public Function MantenimientoFactGas(ByVal pFactTelefonica As ETFacturaTelefonica, ByVal pOpcion As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoFactGas)

        Dim trama As String = ""
        Dim Resultado As New ETResultado
        Resultado.Realizo = False

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "OPE", DbType.Int32, pFactTelefonica.Ope)
                db.AddInParameter(cmd, "ID", DbType.Int32, pFactTelefonica.ID)
                db.AddInParameter(cmd, "COD_PROV", DbType.String, pFactTelefonica.CodProv)
                db.AddInParameter(cmd, "TIPO_DOC", DbType.String, pFactTelefonica.TipoDoc)
                db.AddInParameter(cmd, "NUMERO", DbType.String, pFactTelefonica.NroDoc)
                db.AddInParameter(cmd, "FECHA", DbType.Date, pFactTelefonica.fecha)
                db.AddInParameter(cmd, "SUBTOTAL", DbType.Decimal, pFactTelefonica.subtotal)
                db.AddInParameter(cmd, "IGV", DbType.Decimal, pFactTelefonica.igv)
                db.AddInParameter(cmd, "TOTAL", DbType.Decimal, pFactTelefonica.total)
                db.AddInParameter(cmd, "USUARIO", DbType.String, pFactTelefonica.Usuario)

                db.AddInParameter(cmd, "LECTURA_ANT", DbType.Decimal, pFactTelefonica.lecturaant)
                db.AddInParameter(cmd, "LECTURA_ACT", DbType.Decimal, pFactTelefonica.lecturaact)
                db.AddInParameter(cmd, "VOL_CONSUMIDO", DbType.Decimal, pFactTelefonica.volconsumido)
                db.AddInParameter(cmd, "FACT_CORRECCION", DbType.Decimal, pFactTelefonica.factcorrecion)
                db.AddInParameter(cmd, "VOL_COND_ESTANDAR", DbType.Decimal, pFactTelefonica.condestandar)
                db.AddInParameter(cmd, "VOL_FACTURADO", DbType.Decimal, pFactTelefonica.volfacturado)
                db.AddInParameter(cmd, "PODER_CALORIFICO", DbType.Decimal, pFactTelefonica.podcalorifico)
                db.AddInParameter(cmd, "VALOR_MIN_DIARIO", DbType.Decimal, pFactTelefonica.mindiario)
                db.AddInParameter(cmd, "GAS_NATURAL", DbType.Decimal, pFactTelefonica.gasnatural)
                db.AddInParameter(cmd, "SERVICIO_TRANSPORTE", DbType.Decimal, pFactTelefonica.servtransporte)

                db.AddInParameter(cmd, "DISTRIBUCION_VARIABLE", DbType.Decimal, pFactTelefonica.distvariable)
                db.AddInParameter(cmd, "DISTRIBUCION_FIJO", DbType.Decimal, pFactTelefonica.distfijo)
                db.AddInParameter(cmd, "COMERCIALIZACION_FIJO", DbType.Decimal, pFactTelefonica.comercializacion)
                db.AddInParameter(cmd, "OTROS_CONCEPTOS", DbType.Decimal, pFactTelefonica.otros)
                db.AddInParameter(cmd, "REDONDEO_ANTERIOR", DbType.Decimal, pFactTelefonica.redondeoant)
                db.AddInParameter(cmd, "REDONDEO_ACT", DbType.Decimal, pFactTelefonica.redondeoact)
                Trans.Commit()
                Return db.ExecuteDataSet(cmd).Tables(0)
                'trama = Convert.ToString(db.ExecuteScalar(cmd, Trans))

                'Dim a() As String = trama.Split("|")

                'If a(0) = "1" Then
                '    Resultado.Realizo = True
                '    Resultado.Valor = Convert.ToInt32(a(2))
                '    Trans.Commit()
                'Else
                '    Trans.Rollback()
                'End If

                'Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using

        'Return Resultado
    End Function

    Public Function ListarGrupos(ByVal CodCia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigCelular_ListarBolsas)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CodCia", DbType.String, CodCia)

            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt
    End Function
    Public Function ListarProveedores(ByVal CodCia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spFactTelefonia_ListarProveedores)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, CodCia)

            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt
    End Function
    Public Function ListarTipoDocumentos(ByVal CodCia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spFactTelefonia_ListarTipoDoc)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CodCia", DbType.String, CodCia)
            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt
    End Function

    Public Function ListarFactGas(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarFactGas)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            'db.AddInParameter(cmd, "CodCia", DbType.String, pFactElect.CodCia)

            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt
    End Function

    Public Function ListarFactGasID(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarFactGasID)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "ID", DbType.String, pFactElect.ID)

            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt
    End Function

    Public Function ListarFactGasCONSUMO(ByVal pFactElect As ETFacturaTelefonica) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarFactGasCONSUMO)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "AYO", DbType.Int32, pFactElect.fecha.Year)
            db.AddInParameter(cmd, "MES", DbType.Int32, pFactElect.fecha.Month)
            db.AddInParameter(cmd, "ID", DbType.Int32, pFactElect.ID)

            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt
    End Function

End Class
