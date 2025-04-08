Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAInsumosFiscalizados

    Public Function Insertar_InsumosFiscalizados(ByVal C As ETInsumosFiscalizados) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFiscalizados.Insertar_InsumosFiscalizados)
        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddOutParameter(cmd, "@Id_Prod", DbType.Int16, 0)
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, C.Cod_Cia)
                db.AddInParameter(cmd, "@Cod_Sunat", DbType.String, C.Cod_Sunat)
                db.AddInParameter(cmd, "@Des_Sunat", DbType.String, C.Des_Sunat)
                db.AddInParameter(cmd, "@Presentacion", DbType.String, C.Presentacion)
                db.AddInParameter(cmd, "@UnidadPre", DbType.String, C.UnidadPre)
                db.AddInParameter(cmd, "@CantidadUniPre", DbType.Decimal, C.CantidadUniPre)
                db.AddInParameter(cmd, "@PesoBruto", DbType.Decimal, C.PesoBruto)
                db.AddInParameter(cmd, "@CodProducto", DbType.String, C.Cod_Producto)
                db.AddInParameter(cmd, "@User_Crea", DbType.String, C.User_Crea)
                db.ExecuteNonQuery(cmd)

                RPTA = Convert.ToInt16(db.GetParameterValue(cmd, "@Id_Prod"))
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
        Return RPTA
    End Function

    Public Function Actualizar_InsumosFiscalizados(ByVal C As ETInsumosFiscalizados) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFiscalizados.Actualizar_InsumosFiscalizados)
        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, C.Id_Prod)
                db.AddInParameter(cmd, "@Des_Sunat", DbType.String, C.Des_Sunat)
                db.AddInParameter(cmd, "@Presentacion", DbType.String, C.Presentacion)
                db.AddInParameter(cmd, "@UnidadPre", DbType.String, C.UnidadPre)
                db.AddInParameter(cmd, "@CantidadUniPre", DbType.Decimal, C.CantidadUniPre)
                db.AddInParameter(cmd, "@PesoBruto", DbType.Decimal, C.PesoBruto)
                db.AddInParameter(cmd, "@CodProducto", DbType.String, C.Cod_Producto)
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

    Public Function Listar_UnidadesDeMedidas(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFiscalizados.Listar_UnidadesDeMedidas)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@Cod_Cia", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_InsumosFiscalizados_x_Cod_Cia(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFiscalizados.Listar_InsumosFiscalizados_x_Cod_Cia)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@Cod_Cia", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Mostrar_InsumosFiscalizados_x_Id_Prod(ByVal pId_Prod As String) As ETInsumosFiscalizados

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFiscalizados.Mostrar_InsumosFiscalizados_x_Id_Prod)

        Dim oInsFisE As ETInsumosFiscalizados = Nothing

        Try
            oInsFisE = New ETInsumosFiscalizados

            db.AddInParameter(cmd, "@Id_Prod", DbType.String, pId_Prod)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    oInsFisE.Id_Prod = dr.GetInt32(dr.GetOrdinal("Id_Prod"))
                    oInsFisE.Cod_Cia = dr.GetString(dr.GetOrdinal("Cod_Cia"))
                    oInsFisE.Cod_Sunat = dr.GetString(dr.GetOrdinal("Cod_Sunat"))
                    oInsFisE.Des_Sunat = dr.GetString(dr.GetOrdinal("Des_Sunat"))
                    oInsFisE.Presentacion = dr.GetString(dr.GetOrdinal("Presentacion"))
                    oInsFisE.UnidadPre = dr.GetString(dr.GetOrdinal("UnidadPre"))
                    oInsFisE.CantidadUniPre = dr.GetDecimal(dr.GetOrdinal("CantidadUniPre"))
                    oInsFisE.PesoBruto = dr.GetDecimal(dr.GetOrdinal("PesoBruto"))
                    oInsFisE.Cod_Producto = dr.GetString(dr.GetOrdinal("CodProducto"))
                    oInsFisE.Status = dr.GetString(dr.GetOrdinal("Status"))
                    oInsFisE.User_Crea = dr.GetString(dr.GetOrdinal("User_Crea"))
                    oInsFisE.Fecha_Crea = dr.GetDateTime(dr.GetOrdinal("Fecha_Crea"))
                End While
                If dr IsNot Nothing Then dr.Close()
            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        Finally
            Mostrar_InsumosFiscalizados_x_Id_Prod = oInsFisE
            oInsFisE = Nothing
        End Try
    End Function

    Public Function Mostrar_ID_PROD_InsumosFiscalizados_x_Cod_SUNAT(ByVal pCod_Cia As String, ByVal pCod_Sunat As String) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFiscalizados.Mostrar_ID_PROD_InsumosFiscalizados_x_Cod_SUNAT)
        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Cod_Cia", DbType.String, pCod_Cia)
                db.AddInParameter(cmd, "@Cod_Sunat", DbType.String, pCod_Sunat)

                RPTA = db.ExecuteScalar(cmd)

                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
        Return RPTA
    End Function

    Public Function Mostrar_Count_InsumosFProductosXId_Prod(ByVal pId_Prod As Integer) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFiscalizados.Mostrar_Count_InsumosFProductosXId_Prod)
        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, pId_Prod)

                RPTA = db.ExecuteScalar(cmd)

                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
        Return RPTA
    End Function

    Public Function Anular_InsumosFiscalizados(ByVal pId_Prod As Integer, ByVal pUser_Modi As String) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFiscalizados.Anular_InsumosFiscalizados)
        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, pId_Prod)
                db.AddInParameter(cmd, "@User_Modi", DbType.String, pUser_Modi)

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

    Public Function Modifica_Iqbf(ByVal Ls_Datos As List(Of ETInsumosFiscalizados)) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                For Each Row In Ls_Datos
                    Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.MODIFICAIQBF)
                    db.AddInParameter(cmd, "@ID", DbType.Int32, Row.Id_Prod)
                    db.AddInParameter(cmd, "@CANTIDAD", DbType.Decimal, Row.cantidad)
                    db.AddInParameter(cmd, "@GUIA", DbType.String, Row.numasociado)
                    db.AddInParameter(cmd, "@GUIATRANSPORTISTA", DbType.String, Row.numguia)
                    db.AddInParameter(cmd, "@PLACA", DbType.String, Row.placa)
                    db.AddInParameter(cmd, "@BREVETE", DbType.String, Row.brevete)
                    db.AddInParameter(cmd, "@TDREMITENTE", DbType.String, Row.tdremitente)
                    db.AddInParameter(cmd, "@TDTRANSPORTISTA", DbType.String, Row.tdtransportista)
                    db.AddInParameter(cmd, "@RUCPROVEEDOR", DbType.String, Row.rucproveedor)
                    db.AddInParameter(cmd, "@RUCTRANSPORTISTA", DbType.String, Row.ructransportista)
                    db.AddInParameter(cmd, "@TDGUIACLIENTE", DbType.String, Row.tdcliente)
                    db.AddInParameter(cmd, "@GUIACLIENTE", DbType.String, Row.guiacliente)
                    db.ExecuteNonQuery(cmd)
                Next

                Trans.Commit()
                Conexion.Close()
                Return 1
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Return 0
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function Cierre_Iqbf(ByVal Datos As ETInsumosFiscalizados) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_ProveedorFiscalizado.CIERRE_MES_IQBF)
                db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "@AYO", DbType.Int32, Datos.ayo)
                db.AddInParameter(cmd, "@MES", DbType.Int32, Datos.mes)
                db.AddInParameter(cmd, "@ESTADO", DbType.Int32, Datos.estado)
                db.AddInParameter(cmd, "@OBSERVACION", DbType.String, Datos.observacion)
                db.AddInParameter(cmd, "@NUMSUNAT", DbType.String, Datos.numsunat)
                db.AddInParameter(cmd, "@FECHAPROCESO", DbType.DateTime, Datos.Fecha_Crea)
                db.AddInParameter(cmd, "@USUARIO", DbType.String, Datos.User_Crea)
                db.ExecuteNonQuery(cmd)

                Trans.Commit()
                Conexion.Close()
                Return 1
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Return 0
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

End Class
