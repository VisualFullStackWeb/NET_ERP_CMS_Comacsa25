Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient

Public Class DATarjetaConsumo


    Public Function ListarLimiteTarjetasConsumo(ByVal idTarjetaConsumo As Integer, ByVal idTipoTarjetaConsumo As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spListarLimiteTarjetasConsumo)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "@IdTarjetaConsumo", DbType.String, idTarjetaConsumo)
            db.AddInParameter(cmd, "@IdTipoTarjetaConsumo", DbType.String, idTipoTarjetaConsumo)

            ds = db.ExecuteDataSet(cmd)

            If ds.Tables.Count > 0 Then
                dt = ds.Tables(0)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return dt


        'Dim trama As String = ""
        'Dim Resultado As New ETResultado
        'Resultado.Realizo = False

        'Using Conexion As DbConnection = db.CreateConnection()

        'Conexion.Open()
        'Dim Trans As DbTransaction = Conexion.BeginTransaction()

        'Try
        'db.AddInParameter(cmd, "@IdTarjetaConsumo", DbType.String, idTarjetaConsumo)
        'db.AddInParameter(cmd, "@IdTipoTarjetaConsumo", DbType.String, idTipoTarjetaConsumo)
        'db.AddOutParameter(cmd, "@Resultado", DbType.String, 10)

        'trama = Convert.ToString(db.ExecuteScalar(cmd, Trans))

        'Dim a() As String = trama.Split("|")

        'If a(0) = "0" Then
        'Resultado.Realizo = True
        'Trans.Commit()
        'Else
        'Trans.Rollback()
        'End If

        'Conexion.Close()

        'Catch Err As Exception
        'Trans.Rollback()
        'Conexion.Close()
        'MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        'Return Nothing
        'End Try
        'End Using

        'Return Resultado

    End Function

    Public Function CargarTipoTarjeta() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.TipoTarjetaConsumo)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

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


    Public Function CargarMonedaTarjeta() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MonedaTarjetaConsumo)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

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

    Public Function CargaEstadoTarjeta() As DataTable
        
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.EstadoTarjetaConsumo)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

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

    Public Function MantenimientoBolsa(ByVal CodCia As String, ByVal CodBolsa As String, ByVal Bolsa As String, ByVal pOpcion As Integer) As ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigCelular_MantenimientoBolsa)

        Dim trama As String = ""
        Dim Resultado As New ETResultado
        Resultado.Realizo = False

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "CodCia", DbType.String, CodCia)
                db.AddInParameter(cmd, "CodBolsa", DbType.String, CodBolsa)
                db.AddInParameter(cmd, "Bolsa", DbType.String, Bolsa)
                db.AddInParameter(cmd, "Operacion", DbType.Int32, pOpcion)

                trama = Convert.ToString(db.ExecuteScalar(cmd, Trans))

                Dim a() As String = trama.Split("|")

                If a(0) = "0" Then
                    Resultado.Realizo = True
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

    ' ListarTarjetaConsumo

    Public Function ListarTarjetaConsumoHistorial(ByVal pTarjetaConsumo As ETTarjetaConsumo) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spTarjetaConsumo_Historial)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "cod_cia", DbType.String, pTarjetaConsumo.CodCia)
            db.AddInParameter(cmd, "placod", DbType.String, pTarjetaConsumo.PlaCod)

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


    Public Function ListarTarjetaConsumo(ByVal pTarjetaConsumo As ETTarjetaConsumo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spTarjetaConsumo_Listar)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "cod_cia", DbType.String, pTarjetaConsumo.CodCia)
            db.AddInParameter(cmd, "placod", DbType.String, pTarjetaConsumo.PlaCod)

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


    Public Function ValidaTarjetaConsumoAsignado(ByVal pAsigTarjetaConsumo As ETTarjetaConsumo, ByVal op As Integer) As ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigTarjetaConsumo_Validar)

        Dim Resultado As New ETResultado

        Resultado.Realizo = False

        Try
            ' Agregar los parámetros de entrada
            db.AddInParameter(cmd, "@PlaCod", DbType.String, pAsigTarjetaConsumo.PlaCod)
            db.AddInParameter(cmd, "@NroTarjeta", DbType.String, pAsigTarjetaConsumo.Nro_Tarjeta.Replace("-", ""))
            'db.AddInParameter(cmd, "@TipoTarjeta", DbType.String, pAsigTarjetaConsumo.Tipo_Tarjeta)
            db.AddInParameter(cmd, "@CodBanco", DbType.String, pAsigTarjetaConsumo.Codigo_Banco)
            db.AddInParameter(cmd, "@Status", DbType.String, "")

            ' Agregar el parámetro de salida
            db.AddOutParameter(cmd, "@Resultado", DbType.String, 10)

            ' Ejecutar el procedimiento almacenado
            db.ExecuteNonQuery(cmd)

            ' Obtener el valor del parámetro de salida
            Dim resultadoSP As String = Convert.ToString(db.GetParameterValue(cmd, "@Resultado"))

            ' Procesar el resultado
            If op = 1 Then
                If resultadoSP = "Valido" Then
                    Resultado.Realizo = True
                    Resultado.Mensaje = "La tarjeta de consumo es válida."
                Else
                    Resultado.Realizo = False
                    Resultado.Mensaje = "La tarjeta de consumo ya está asignada."
                End If
            Else
                Resultado.Realizo = True
            End If

        Catch ex As Exception
            ' Registrar el error (opcional: usar un sistema de logging)
            ' LogError(ex.Message)
            Resultado.Realizo = False
            Resultado.Mensaje = "Ocurrió un error al validar la tarjeta de consumo."
        End Try

        Return Resultado
    End Function

    Public Function ValidaTarjetaConsumoAsignado_old(ByVal pAsigTarjetaConsumo As ETTarjetaConsumo) As ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigTarjetaConsumo_Validar)

        Dim trama As String = ""
        Dim Resultado As New ETResultado
        Resultado.Realizo = False

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                ' Agregar los parámetros de entrada
                db.AddInParameter(cmd, "@PlaCod", DbType.String, pAsigTarjetaConsumo.PlaCod)
                db.AddInParameter(cmd, "@NroTarjeta", DbType.String, pAsigTarjetaConsumo.Nro_Tarjeta.Replace("-", ""))
                'db.AddInParameter(cmd, "@TipoTarjeta", DbType.String, pAsigTarjetaConsumo.Tipo_Tarjeta)
                db.AddInParameter(cmd, "@CodBanco", DbType.String, pAsigTarjetaConsumo.Codigo_Banco)
                db.AddInParameter(cmd, "@Status", DbType.String, "")
                db.AddInParameter(cmd, "@Resultado", SqlDbType.VarChar, 10)

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

    'Public Function MantenimientoTarjetaConsumoAsignado(ByVal pAsigTarjetaConsumo As ETTarjetaConsumo, ByVal pOpcion As Integer) As ETResultado
    '    Dim db As Database = DatabaseFactory.CreateDatabase()

    '    Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigTarjetaConsumo_Mantenimiento25)

    '    Dim trama As String = ""
    '    Dim Resultado As New ETResultado
    '    Resultado.Realizo = False

    '    Using Conexion As DbConnection = db.CreateConnection()

    '        Conexion.Open()
    '        Dim Trans As DbTransaction = Conexion.BeginTransaction()

    '        Try
    '            db.AddInParameter(cmd, "CodCia", DbType.String, pAsigTarjetaConsumo.CodCia)
    '            db.AddInParameter(cmd, "ID", DbType.String, pAsigTarjetaConsumo.ID)
    '            db.AddInParameter(cmd, "PlaCod", DbType.String, pAsigTarjetaConsumo.PlaCod)
    '            db.AddInParameter(cmd, "NroTarjeta", DbType.String, pAsigTarjetaConsumo.Nro_Tarjeta.Replace("-", ""))
    '            db.AddInParameter(cmd, "TipoTarjeta", DbType.String, pAsigTarjetaConsumo.Tipo_Tarjeta)
    '            db.AddInParameter(cmd, "CodBanco", DbType.String, pAsigTarjetaConsumo.Codigo_Banco)
    '            db.AddInParameter(cmd, "FecEmision ", DbType.String, pAsigTarjetaConsumo.Fecha_Emision)
    '            db.AddInParameter(cmd, "FecVcmto", DbType.String, pAsigTarjetaConsumo.Fecha_Vcmto)
    '            db.AddInParameter(cmd, "SaldoIni", DbType.String, pAsigTarjetaConsumo.Saldo_Inicial)
    '            db.AddInParameter(cmd, "EstadoTarjeta", DbType.String, pAsigTarjetaConsumo.Estado_Tarjeta)
    '            db.AddInParameter(cmd, "MonedaTarjeta", DbType.String, pAsigTarjetaConsumo.Moneda_Tarjeta)
    '            db.AddInParameter(cmd, "Usuario", DbType.String, pAsigTarjetaConsumo.Usuario)
    '            db.AddInParameter(cmd, "Operacion", DbType.Int32, pOpcion)

    '            trama = Convert.ToString(db.ExecuteScalar(cmd, Trans))

    '            Dim a() As String = trama.Split("|")

    '            If a(0) = "1" Then
    '                Resultado.Realizo = True
    '                Resultado.Valor = Convert.ToInt32(a(2))
    '                Trans.Commit()
    '            Else
    '                Trans.Rollback()
    '            End If

    '            Conexion.Close()

    '        Catch Err As Exception
    '            Trans.Rollback()
    '            Conexion.Close()
    '            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
    '            Return Nothing
    '        End Try

    '    End Using

    '    Return Resultado
    'End Function

    Public Function MantenimientoTarjetaConsumoAsignado(ByVal pAsigTarjetaConsumo As ETTarjetaConsumo, ByVal pOpcion As Integer) As ETResultado

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigTarjetaConsumo_Mantenimiento25)
        Dim resultado As New ETResultado With {.Realizo = False}

        Try

            ' Agregar parámetros
            db.AddInParameter(cmd, "CodCia", DbType.String, pAsigTarjetaConsumo.CodCia)
            db.AddInParameter(cmd, "ID", DbType.String, pAsigTarjetaConsumo.ID)
            db.AddInParameter(cmd, "PlaCod", DbType.String, pAsigTarjetaConsumo.PlaCod)
            db.AddInParameter(cmd, "NroTarjeta", DbType.String, pAsigTarjetaConsumo.Nro_Tarjeta.Replace("-", ""))
            'db.AddInParameter(cmd, "TipoTarjeta", DbType.String, pAsigTarjetaConsumo.Tipo_Tarjeta)
            db.AddInParameter(cmd, "CodBanco", DbType.String, pAsigTarjetaConsumo.Codigo_Banco)

            db.AddInParameter(cmd, "FecEmision", DbType.String, pAsigTarjetaConsumo.Fecha_Emision)
            db.AddInParameter(cmd, "FecVcmto", DbType.String, pAsigTarjetaConsumo.Fecha_Vcmto)

            db.AddInParameter(cmd, "SaldoIni", DbType.String, pAsigTarjetaConsumo.Saldo_Inicial)
            db.AddInParameter(cmd, "SaldoIni1", DbType.String, pAsigTarjetaConsumo.Saldo_Inicial1)

            db.AddInParameter(cmd, "EstadoTarjeta", DbType.String, pAsigTarjetaConsumo.Estado_Tarjeta)
            db.AddInParameter(cmd, "MonedaTarjeta", DbType.String, pAsigTarjetaConsumo.Moneda_Tarjeta)
            db.AddInParameter(cmd, "Usuario", DbType.String, pAsigTarjetaConsumo.Usuario)
            db.AddInParameter(cmd, "Operacion", DbType.Int32, pOpcion)

            ' Ejecutar sin transacción
            Dim trama As String = Convert.ToString(db.ExecuteScalar(cmd))
            Dim partes() As String = trama.Split("|"c)

            If partes.Length >= 3 AndAlso partes(0) = "1" Then
                resultado.Realizo = True
                resultado.Valor = Convert.ToInt32(partes(2))
            Else
                resultado.Realizo = False
            End If

        Catch ex As Exception
            ' Manejo de errores (reemplazar MsgBox por logging en producción)
            cmd.Connection.Close()
            MsgBox(ex.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        Finally
            If cmd.Connection IsNot Nothing AndAlso cmd.Connection.State = ConnectionState.Open Then
                cmd.Connection.Close()
            End If
        End Try

        Return resultado
    End Function
    

End Class

