Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DACanteraCosteo


    Public Function ObtenerDescripcionCantera(ByVal Cantera As String) As String

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DescripcionCantera)
        Dim lResult As String = String.Empty

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Cantera)
            lResult = db.ExecuteScalar(cmd)
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = String.Empty
        End Try

        Return lResult

    End Function

    Public Function ObtenerOrigenCantera(ByVal Cantera As String) As String

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.OrigenCantera)
        Dim lResult As String = String.Empty

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Cantera)
            lResult = db.ExecuteScalar(cmd)
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = String.Empty
        End Try

        Return lResult

    End Function

    '   ****    CANTERA -   VIAJE               ****
    Public Function ConsultarCanteraViaje(ByVal CanteraViaje As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraViaje)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "CodCia", DbType.String, CanteraViaje.CodCia)
            db.AddInParameter(cmd, "Opcion", DbType.String, CanteraViaje.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID").ToString)
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .CodEmpleado = dr.GetString(dr.GetOrdinal("CodigoEmpleado").ToString)
                        .Empleado = dr.GetString(dr.GetOrdinal("Empleado").ToString)
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaFin = dr.GetDateTime(dr.GetOrdinal("FechaFin"))
                        .NroDias = dr.GetInt32(dr.GetOrdinal("NroDias"))
                        .CodArea = dr.GetString(dr.GetOrdinal("Area").ToString)
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function ConsultarCanteraViajeDetalle(ByVal CanteraViaje As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraViaje)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "ID", DbType.String, CanteraViaje.ID)
            db.AddInParameter(cmd, "CodCia", DbType.String, CanteraViaje.CodCia)
            db.AddInParameter(cmd, "Opcion", DbType.String, CanteraViaje.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                        .Ubigeo = dr.GetString(dr.GetOrdinal("Ubigeo"))
                        .DescripcionUbigeo = dr.GetString(dr.GetOrdinal("DescripcionUbigeo"))
                        .Motivo = dr.GetString(dr.GetOrdinal("Motivo"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCanteraViaje(ByVal U As ETCanteraCosteo, ByVal D As List(Of ETCanteraCosteo)) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraViaje)
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "ID", DbType.String, U.ID)
                db.AddInParameter(cmd, "CodCia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodEmpleado", DbType.String, U.CodEmpleado)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, U.FechaInicio)
                db.AddInParameter(cmd, "FechaFin", DbType.DateTime, U.FechaFin)
                db.AddInParameter(cmd, "NroDias", DbType.Int32, U.NroDias)
                db.AddInParameter(cmd, "CodArea", DbType.String, U.CodArea)
                db.AddInParameter(cmd, "User", DbType.String, U.User)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, U.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))


                If D IsNot Nothing Then
                    If D.Count > 0 And (U.Opcion = 1) Then
                        For Each xRow As ETCanteraCosteo In D
                            Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraViajeDetalle)

                            db.AddInParameter(xmd, "ID", DbType.String, Right(("0000000000" & ETResultado.Mensaje.TrimEnd.TrimStart), 10))
                            db.AddInParameter(xmd, "CodCia", DbType.String, Companhia)
                            db.AddInParameter(xmd, "Ubigeo", DbType.String, xRow.Ubigeo)
                            db.AddInParameter(xmd, "Cantera", DbType.String, xRow.CodigoCantera)
                            db.AddInParameter(xmd, "Porcentaje", DbType.Double, xRow.Porcentaje)
                            db.AddInParameter(xmd, "User", DbType.String, xRow.User)
                            db.AddInParameter(xmd, "Motivo", DbType.String, xRow.Motivo)
                            db.AddInParameter(xmd, "Opcion", DbType.Int16, xRow.Opcion)
                            db.ExecuteNonQuery(xmd, Trans)

                        Next

                    End If

                End If

                If IntRes = -1 Then
                    Err.Raise(10)
                End If
                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function ValidarCanteraViaje(ByVal ViajeCantera As ETCanteraCosteo) As Boolean
        Dim IntRes As Integer = -1
        Dim Resultado As Boolean = True
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraViaje)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            db.AddInParameter(cmd, "CodCia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.String, ViajeCantera.ID)
            db.AddInParameter(cmd, "CodEmpleado", DbType.String, ViajeCantera.CodEmpleado)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, ViajeCantera.FechaInicio)
            db.AddInParameter(cmd, "FechaFin", DbType.DateTime, ViajeCantera.FechaFin)
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, ViajeCantera.Opcion)
            IntRes = db.ExecuteNonQuery(cmd)
            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

            If Val(ETResultado.Mensaje) = 0 Then
                Resultado = True
            Else
                Resultado = False
            End If

            Conexion.Close()

        End Using

        Return Resultado

    End Function

    '   ****    CANTERA -   EQUIPO              ****
    Public Function ConsultarUbicacionEquipoCantera(ByVal CanteraViaje As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, CanteraViaje.CodCia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, CanteraViaje.CodigoCantera)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, CanteraViaje.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .Tipo = dr.GetString(dr.GetOrdinal("Tipo"))
                        .NombreTipo = dr.GetString(dr.GetOrdinal("NombreTipo"))
                        .Cod_Equipo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .NombreEquipo = dr.GetString(dr.GetOrdinal("NombreEquipo"))
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        If Not (dr.IsDBNull(dr.GetOrdinal("FechaFin"))) Then
                            .FechaFin = dr.GetDateTime(dr.GetOrdinal("FechaFin"))
                        End If

                        .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                        .Movimiento = dr.GetString(dr.GetOrdinal("Movimiento"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCanteraEquipo(ByVal CanteraEquipo As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraEquipo)
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "ID", DbType.String, CanteraEquipo.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, CanteraEquipo.CodigoCantera)
                db.AddInParameter(cmd, "Cod_Equipo", DbType.String, CanteraEquipo.Cod_Equipo)
                db.AddInParameter(cmd, "Tipo", DbType.String, CanteraEquipo.Tipo)
                db.AddInParameter(cmd, "User", DbType.String, CanteraEquipo.User)
                db.AddInParameter(cmd, "Fecha_Inicio", DbType.DateTime, CanteraEquipo.FechaInicio)

                If CanteraEquipo.Chk = 1 Then
                    db.AddInParameter(cmd, "Fecha_Fin", DbType.DateTime, CanteraEquipo.FechaFin)
                End If
                db.AddInParameter(cmd, "Movimiento", DbType.String, CanteraEquipo.Movimiento)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, 1)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function EliminarCanteraEquipo(ByVal CanteraEquipo As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraEquipo)
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "ID", DbType.String, CanteraEquipo.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, CanteraEquipo.CodigoCantera)
                db.AddInParameter(cmd, "Cod_Equipo", DbType.String, CanteraEquipo.Cod_Equipo)
                db.AddInParameter(cmd, "Tipo", DbType.String, CanteraEquipo.Tipo)
                db.AddInParameter(cmd, "User", DbType.String, CanteraEquipo.User)
                db.AddInParameter(cmd, "Movimiento", DbType.String, CanteraEquipo.Movimiento)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, CanteraEquipo.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function ValidarCanteraEquipo(ByVal CanteraEquipo As ETCanteraCosteo) As Boolean
        Dim IntRes As Integer = -1
        Dim Resultado As Boolean = True
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraEquipo)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.String, CanteraEquipo.ID)
            db.AddInParameter(cmd, "Cod_Equipo", DbType.String, CanteraEquipo.Cod_Equipo)
            db.AddInParameter(cmd, "Fecha_Inicio", DbType.DateTime, CanteraEquipo.FechaInicio)
            db.AddInParameter(cmd, "Fecha_Fin", DbType.DateTime, CanteraEquipo.FechaFin)
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, CanteraEquipo.Opcion)
            IntRes = db.ExecuteNonQuery(cmd)
            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

            If ETResultado.Mensaje = 1 Then
                Resultado = True
            Else
                Resultado = False
            End If

            Conexion.Close()

        End Using

        Return Resultado

    End Function

    '   ****    COMBUSTIBLE -   EXPLOSIVO       ****
    Public Function ListarCanteraCombustibleExplosivo(ByVal CombustibleExplosivo As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CombustibleExplosivo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, CombustibleExplosivo.CodCia)
            db.AddInParameter(cmd, "Cantera", DbType.String, CombustibleExplosivo.CodigoCantera)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, CombustibleExplosivo.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Tipo = dr.GetString(dr.GetOrdinal("CodigoTipo"))
                        .NombreTipo = dr.GetString(dr.GetOrdinal("Tipo"))
                        .CodProd = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Producto"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Cod_Equipo = dr.GetString(dr.GetOrdinal("CodigoEquipo"))
                        .NombreEquipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .UM = dr.GetString(dr.GetOrdinal("Unidad"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .Periodo = dr.GetString(dr.GetOrdinal("Tipo_Equipo"))
                        .Linea = dr.GetString(dr.GetOrdinal("DescripcionTipoEquipo"))
                        .TipoTrabajo = dr.GetString(dr.GetOrdinal("TipoTrabajo"))
                        .DescripTipoTrabajo = dr.GetString(dr.GetOrdinal("DescripTipoTrabajo"))
                        .Motivo = dr.GetString(dr.GetOrdinal("Motivo"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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


    Public Function ListarPrecioCombustibleExplosivo(ByVal CombustibleExplosivo As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.PrecioCombustibleExplosivo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "CIA", DbType.String, CombustibleExplosivo.CodCia)
            'db.AddInParameter(cmd, "Cantera", DbType.String, CombustibleExplosivo.CodigoCantera)
            'db.AddInParameter(cmd, "Opcion", DbType.Int32, CombustibleExplosivo.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Ano = dr.GetInt32(dr.GetOrdinal("AÑO"))
                        .Mes = dr.GetInt32(dr.GetOrdinal("MES"))
                        .NombreTipo = dr.GetString(dr.GetOrdinal("TIPO"))
                        .CodProd = dr.GetString(dr.GetOrdinal("CODPROD"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("DESCRIP"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("PRECIO"))
                        .UM = dr.GetString(dr.GetOrdinal("UNID_DESP"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CODCANTERA"))
                        .Cantera = dr.GetString(dr.GetOrdinal("CANTERA"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCombustibleExplosivo(ByVal U As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CombustibleExplosivo)
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.String, U.ID)
                db.AddInParameter(cmd, "CodCia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Tipo", DbType.String, U.Tipo)
                db.AddInParameter(cmd, "CodProd", DbType.String, U.CodProd)
                db.AddInParameter(cmd, "Descripcion", DbType.String, U.Descripcion)
                db.AddInParameter(cmd, "Cantidad", DbType.Decimal, U.Importe)
                db.AddInParameter(cmd, "UM", DbType.String, U.UM)
                db.AddInParameter(cmd, "Cantera", DbType.String, U.CodigoCantera)
                db.AddInParameter(cmd, "Equipo", DbType.String, U.Cod_Equipo)
                db.AddInParameter(cmd, "User", DbType.String, U.User)
                db.AddInParameter(cmd, "Tipo_Equipo", DbType.String, U.NombreTipo)
                db.AddInParameter(cmd, "Fec_Registro", DbType.DateTime, U.Fecha)
                db.AddInParameter(cmd, "TipoTrabajo", DbType.String, U.TipoTrabajo)
                db.AddInParameter(cmd, "Motivo", DbType.String, U.Motivo)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, U.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))
                If IntRes = -1 Then
                    Err.Raise(10)
                End If
                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function MantenimientoPrecioCombustibleExplosivo(ByVal U As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MantPrecioCombustibleExplosivo)
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "AÑO", DbType.String, U.Ano)
                db.AddInParameter(cmd, "MES", DbType.String, U.Mes)
                db.AddInParameter(cmd, "TIPO", DbType.String, U.Tipo)
                db.AddInParameter(cmd, "CODPROD", DbType.Decimal, U.CodProd)
                db.AddInParameter(cmd, "PRECIO", DbType.String, U.Importe)
                db.AddInParameter(cmd, "OPCION", DbType.Int32, U.Opcion)
                db.AddInParameter(cmd, "USUARIO", DbType.String, U.User)
                db.AddInParameter(cmd, "CANTERA", DbType.String, U.CodigoCantera)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                If IntRes = -1 Then
                    Err.Raise(10)
                End If
                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function



    '   ****    CANTERA -   VIGENCIA            ****
    Public Function ConsultarCanteraVigencia(ByVal CanteraVigencia As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraVigencia)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, CanteraVigencia.CodCia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, CanteraVigencia.CodigoCantera)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, CanteraVigencia.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Ano = dr.GetInt32(dr.GetOrdinal("Periodo"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Importe"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCanteraVigencia(ByVal U As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraVigencia)
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.String, U.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Periodo", DbType.String, U.Ano)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, U.CodigoCantera)
                db.AddInParameter(cmd, "Moneda", DbType.String, U.Moneda)
                db.AddInParameter(cmd, "Importe", DbType.Decimal, U.Importe)
                db.AddInParameter(cmd, "User", DbType.String, U.User)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, U.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))
                If IntRes = -1 Then
                    Err.Raise(10)
                End If
                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function ValidarCanteraVigencia(ByVal CanteraVigencia As ETCanteraCosteo) As Boolean
        Dim IntRes As Integer = -1
        Dim Resultado As Boolean = True
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraVigencia)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.String, CanteraVigencia.ID)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, CanteraVigencia.CodigoCantera)
            db.AddInParameter(cmd, "Periodo", DbType.Int32, CanteraVigencia.Ano)
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, CanteraVigencia.Opcion)
            IntRes = db.ExecuteNonQuery(cmd)
            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

            If ETResultado.Mensaje = 1 Then
                Resultado = True
            Else
                Resultado = False
            End If

            Conexion.Close()

        End Using

        Return Resultado

    End Function

    '   ****    CANTERA -   VIDA UTIL EQUIPOS   ****
    Public Function ConsultarVidaUtil(ByVal VidaUtil As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.VidaUtil)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, VidaUtil.CodCia)
            db.AddInParameter(cmd, "Opcion", DbType.String, VidaUtil.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function ListarCanteraVidaUtilEquipo(ByVal VidaUtil As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.VidaUtil)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, VidaUtil.CodCia)
            db.AddInParameter(cmd, "CodLinea", DbType.String, VidaUtil.Linea)
            db.AddInParameter(cmd, "CodSubLinea", DbType.String, VidaUtil.SubLinea)
            db.AddInParameter(cmd, "Cantera", DbType.String, VidaUtil.Cantera)
            db.AddInParameter(cmd, "Opcion", DbType.String, VidaUtil.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        If Not (VidaUtil.Opcion = 3) Then
                            .CodProd = dr.GetString(dr.GetOrdinal("Codigo"))
                            .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                            .UM = dr.GetString(dr.GetOrdinal("Unidad"))
                            .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                            .NumeroPeriodo = dr.GetDecimal(dr.GetOrdinal("NumeroPeriodo"))
                        Else
                            .CodigoCantera = dr.GetString(dr.GetOrdinal("Codigo"))
                            .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        End If
                        .Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoVidaUtil(ByVal Producto As List(Of ETCanteraCosteo)) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                For Each T In Producto
                    Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraVidaUtil)

                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd, "Cod_Cantera", DbType.String, T.CodigoCantera)
                    db.AddInParameter(cmd, "Cod_Prod", DbType.String, T.CodProd)
                    db.AddInParameter(cmd, "Cod_Periodo", DbType.String, T.Periodo)
                    db.AddInParameter(cmd, "Num_Periodo", DbType.Decimal, T.NumeroPeriodo)
                    db.AddInParameter(cmd, "User", DbType.String, T.User)
                    db.AddInParameter(cmd, "Opcion", DbType.Int32, T.Opcion)
                    IntRes = db.ExecuteNonQuery(cmd, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Next

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    '   ****    CANTERA -   HORA MAQUINA        ****
    Public Function ListarCanteraHoraMaquina(ByVal HoraMaquina As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.HoraMaquina)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, HoraMaquina.CodCia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, HoraMaquina.CodigoCantera)
            db.AddInParameter(cmd, "Opcion", DbType.String, HoraMaquina.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Cod_Equipo = dr.GetString(dr.GetOrdinal("CodigoEquipo"))
                        .NombreEquipo = dr.GetString(dr.GetOrdinal("NombreEquipo"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Hora = dr.GetDecimal(dr.GetOrdinal("Hora"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Entrada"))
                        .Importe2 = dr.GetDecimal(dr.GetOrdinal("Salida"))
                        .Tipo = dr.GetString(dr.GetOrdinal("Tipo_Equipo"))
                        .Periodo = dr.GetString(dr.GetOrdinal("Tipo_Periodo"))
                        .NombreTipo = dr.GetString(dr.GetOrdinal("Periodo"))
                        .TipoTrabajo = dr.GetString(dr.GetOrdinal("Tipo_Trabajo"))
                        .NombreTipoTrabajo = dr.GetString(dr.GetOrdinal("NombreTipoTrabajo"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCanteraHoraMaquina(ByVal HoraMaquina As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.HoraMaquina)
                db.AddInParameter(cmd, "ID", DbType.String, HoraMaquina.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, HoraMaquina.CodigoCantera)
                db.AddInParameter(cmd, "Cod_Equipo", DbType.String, HoraMaquina.Cod_Equipo)
                db.AddInParameter(cmd, "Fecha", DbType.DateTime, HoraMaquina.Fecha)
                db.AddInParameter(cmd, "Hora", DbType.Decimal, HoraMaquina.Hora)
                db.AddInParameter(cmd, "Entrada", DbType.Decimal, HoraMaquina.Importe)
                db.AddInParameter(cmd, "Salida", DbType.Decimal, HoraMaquina.Importe2)
                db.AddInParameter(cmd, "User", DbType.String, HoraMaquina.User)
                db.AddInParameter(cmd, "Tipo_Equipo", DbType.String, HoraMaquina.Tipo)
                db.AddInParameter(cmd, "Tipo_Periodo", DbType.String, HoraMaquina.Periodo)
                db.AddInParameter(cmd, "Tipo_Trabajo", DbType.String, HoraMaquina.TipoTrabajo)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, HoraMaquina.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function ValidarCanteraHoraMaquina(ByVal HoraMaquina As ETCanteraCosteo) As Boolean
        Dim IntRes As Integer = -1
        Dim Resultado As Boolean = True
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.HoraMaquina)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            db.AddInParameter(cmd, "ID", DbType.String, HoraMaquina.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Fecha", DbType.Date, HoraMaquina.Fecha)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, HoraMaquina.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Equipo", DbType.String, HoraMaquina.Cod_Equipo)
            db.AddInParameter(cmd, "Tipo_Periodo", DbType.String, HoraMaquina.Periodo)
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, HoraMaquina.Opcion)
            IntRes = db.ExecuteNonQuery(cmd)
            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

            If ETResultado.Mensaje = 1 Then
                Resultado = True
            Else
                Resultado = False
            End If

            Conexion.Close()

        End Using

        Return Resultado

    End Function
    Public Function ValidarCanteraHoraMaquina_TotalHoras(ByVal HoraMaquina As ETCanteraCosteo) As Double
        Dim Resultado As Double = 0

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.HoraMaquina)

        db.AddInParameter(cmd, "ID", DbType.String, HoraMaquina.ID)
        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Cod_Equipo", DbType.String, HoraMaquina.Cod_Equipo)
        db.AddInParameter(cmd, "Fecha", DbType.Date, HoraMaquina.Fecha)
        db.AddInParameter(cmd, "Tipo_Periodo", DbType.String, HoraMaquina.Periodo)
        db.AddInParameter(cmd, "Opcion", DbType.Int16, HoraMaquina.Opcion)
        Resultado = db.ExecuteScalar(cmd)
        Return Resultado
    End Function

    '   ****    CANTERA -   HORAS DISPONIBLES MAQUINA        ****

    Public Function MantenimientoCanteraHoraDisponibleMaquina(ByVal HoraDisponibleMaquina As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.HoraDisponibleMaquina)
                db.AddInParameter(cmd, "ID", DbType.String, HoraDisponibleMaquina.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Anio", DbType.Int32, HoraDisponibleMaquina.Ano)
                db.AddInParameter(cmd, "Mes", DbType.Int32, HoraDisponibleMaquina.Mes)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, HoraDisponibleMaquina.CodigoCantera)
                db.AddInParameter(cmd, "Cod_Equipo", DbType.String, HoraDisponibleMaquina.Cod_Equipo)
                db.AddInParameter(cmd, "Cantidad", DbType.Decimal, HoraDisponibleMaquina.Hora)
                db.AddInParameter(cmd, "User", DbType.String, HoraDisponibleMaquina.User)
                db.AddInParameter(cmd, "Tipo_Equipo", DbType.String, HoraDisponibleMaquina.Tipo)
                db.AddInParameter(cmd, "Tipo_Periodo", DbType.String, HoraDisponibleMaquina.Periodo)
                db.AddInParameter(cmd, "Status", DbType.String, "")
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, HoraDisponibleMaquina.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function ValidarCanteraHoraDisponibleMaquina(ByVal HoraDisponibleMaquina As ETCanteraCosteo) As Boolean
        Dim IntRes As Integer = -1
        Dim Resultado As Boolean = True
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.HoraDisponibleMaquina)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            db.AddInParameter(cmd, "ID", DbType.String, HoraDisponibleMaquina.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Anio", DbType.Int32, HoraDisponibleMaquina.Ano)
            db.AddInParameter(cmd, "Mes", DbType.Int16, HoraDisponibleMaquina.Mes)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, HoraDisponibleMaquina.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Equipo", DbType.String, HoraDisponibleMaquina.Cod_Equipo)
            db.AddInParameter(cmd, "Tipo_Periodo", DbType.String, HoraDisponibleMaquina.Periodo)
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, HoraDisponibleMaquina.Opcion)
            IntRes = db.ExecuteNonQuery(cmd)
            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

            If ETResultado.Mensaje = 1 Then
                Resultado = True
            Else
                Resultado = False
            End If

            Conexion.Close()

        End Using

        Return Resultado

    End Function

    Public Function ListarCanteraHoraDisponibleMaquina(ByVal HoraMaquina As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.HoraDisponibleMaquina)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, HoraMaquina.CodCia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, HoraMaquina.CodigoCantera)
            db.AddInParameter(cmd, "Opcion", DbType.String, HoraMaquina.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Ano = dr.GetInt32(dr.GetOrdinal("Ano"))
                        .Mes = dr.GetInt16(dr.GetOrdinal("Mes"))
                        .MesName = dr.GetString(dr.GetOrdinal("MesName"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Cod_Equipo = dr.GetString(dr.GetOrdinal("CodigoEquipo"))
                        .NombreEquipo = dr.GetString(dr.GetOrdinal("NombreEquipo"))
                        .Hora = dr.GetDecimal(dr.GetOrdinal("Hora"))
                        .Tipo = dr.GetString(dr.GetOrdinal("Tipo_Equipo"))
                        .Periodo = dr.GetString(dr.GetOrdinal("Tipo_Periodo"))
                        .NombreTipo = dr.GetString(dr.GetOrdinal("Periodo"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    '   ****    CANTERA -   DERECHO DE CESION   ****
    Public Function ConsultarCanteraDerechoCesion(ByVal DerechoCesion As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DerechoCesion)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, DerechoCesion.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, DerechoCesion.CodCia)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, DerechoCesion.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Importe"))
                        .Importe2 = dr.GetDecimal(dr.GetOrdinal("ImporteAnual"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaFin = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCanteraDerechoCesion(ByVal DerechoCesion As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DerechoCesion)
                db.AddInParameter(cmd, "ID", DbType.String, DerechoCesion.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, DerechoCesion.CodigoCantera)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, DerechoCesion.FechaInicio)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, DerechoCesion.FechaFin)
                db.AddInParameter(cmd, "Importe", DbType.Decimal, DerechoCesion.Importe)
                db.AddInParameter(cmd, "ImporteAnual", DbType.Decimal, DerechoCesion.Importe2)
                db.AddInParameter(cmd, "User", DbType.String, DerechoCesion.User)
                db.AddInParameter(cmd, "Moneda", DbType.String, DerechoCesion.Moneda)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, DerechoCesion.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function ValidarCanteraDerechoCesion(ByVal DerechoCesion As ETCanteraCosteo) As Boolean
        Dim IntRes As Integer = -1
        Dim Resultado As Boolean = True
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DerechoCesion)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            db.AddInParameter(cmd, "ID", DbType.String, DerechoCesion.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, DerechoCesion.CodigoCantera)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, DerechoCesion.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, DerechoCesion.FechaFin)
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, DerechoCesion.Opcion)
            IntRes = db.ExecuteNonQuery(cmd)
            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

            If ETResultado.Mensaje = 1 Then
                Resultado = True
            Else
                Resultado = False
            End If

            Conexion.Close()

        End Using

        Return Resultado

    End Function

    '   ****    CANTERA -   DONACIONES          ****
    Public Function ConsultarCanteraDonacionesMensual(ByVal Donacion As ETCanteraCosteo) As Double

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraDonaciones)
        Dim lResult As Double = 0

        Try

            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Donacion.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Donacion.CodCia)
            db.AddInParameter(cmd, "Ano", DbType.Int32, Donacion.Ano)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Donacion.Mes)
            db.AddInParameter(cmd, "Moneda", DbType.String, Donacion.Moneda)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, Donacion.Opcion)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function
    Public Function ConsultarCanteraDonaciones(ByVal DerechoCesion As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraDonaciones)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, DerechoCesion.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, DerechoCesion.CodCia)
            db.AddInParameter(cmd, "Ano", DbType.Int32, DerechoCesion.Ano)
            db.AddInParameter(cmd, "Mes", DbType.Int16, DerechoCesion.Mes)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, DerechoCesion.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Importe"))
                        .Importe2 = dr.GetDecimal(dr.GetOrdinal("ImporteMensual"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .MesName = dr.GetString(dr.GetOrdinal("MesName"))
                        .Glosa = dr.GetString(dr.GetOrdinal("Glosa"))
                        .Mes = dr.GetInt16(dr.GetOrdinal("Mes"))
                        .Ano = dr.GetInt32(dr.GetOrdinal("Ano"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCanteraDonaciones(ByVal DerechoCesion As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraDonaciones)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.String, DerechoCesion.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, DerechoCesion.CodigoCantera)
                db.AddInParameter(cmd, "Ano", DbType.Int32, DerechoCesion.Ano)
                db.AddInParameter(cmd, "Mes", DbType.Int16, DerechoCesion.Mes)
                db.AddInParameter(cmd, "Cantidad", DbType.Double, DerechoCesion.Cantidad)
                db.AddInParameter(cmd, "Glosa", DbType.String, DerechoCesion.Glosa)
                db.AddInParameter(cmd, "Importe", DbType.Decimal, DerechoCesion.Importe)
                db.AddInParameter(cmd, "User", DbType.String, DerechoCesion.User)
                db.AddInParameter(cmd, "Moneda", DbType.String, DerechoCesion.Moneda)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, DerechoCesion.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function ValidarCanteraDonaciones(ByVal Donaciones As ETCanteraCosteo) As Boolean
        Dim IntRes As Integer = -1
        Dim Resultado As Boolean = True
        Dim ETResultado As New ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraDonaciones)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ID", DbType.String, Donaciones.ID)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Donaciones.CodigoCantera)
            db.AddInParameter(cmd, "Ano", DbType.Int32, Donaciones.Ano)
            db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, Donaciones.Opcion)
            IntRes = db.ExecuteNonQuery(cmd)
            ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

            If ETResultado.Mensaje = 1 Then
                Resultado = True
            Else
                Resultado = False
            End If

            Conexion.Close()

        End Using

        Return Resultado

    End Function

    '   ****    CANTERA -   LISTA DE PRECIO     ****
    Public Function MantenimientoCanteraListaPrecio(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecio)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.String, ListaPrecio.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
                db.AddInParameter(cmd, "Cod_Equipo", DbType.String, ListaPrecio.Cod_Equipo)
                db.AddInParameter(cmd, "Tercero", DbType.Boolean, ListaPrecio.Tercero)
                db.AddInParameter(cmd, "Cod_Proveedor", DbType.String, ListaPrecio.CodigoProveedor)
                db.AddInParameter(cmd, "Precio", DbType.Decimal, ListaPrecio.Importe)
                db.AddInParameter(cmd, "User", DbType.String, ListaPrecio.User)
                db.AddInParameter(cmd, "Fecha_Inicio", DbType.DateTime, ListaPrecio.Fecha)
                db.AddInParameter(cmd, "Moneda", DbType.String, ListaPrecio.Moneda)
                db.AddInParameter(cmd, "Tipo_Periodo", DbType.String, ListaPrecio.Periodo)
                db.AddInParameter(cmd, "Tipo_Equipo", DbType.String, ListaPrecio.NombreTipo)
                db.AddInParameter(cmd, "HorasMin", DbType.Decimal, ListaPrecio.Hora)
                db.AddInParameter(cmd, "Tipo_PerMin", DbType.String, ListaPrecio.TipoPerMin)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, ListaPrecio.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function
    Public Function MantenimientoCanteraListaPrecioFlete(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecioFlete)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.String, ListaPrecio.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
                db.AddInParameter(cmd, "Cod_Proveedor", DbType.String, ListaPrecio.CodigoProveedor)
                db.AddInParameter(cmd, "Precio", DbType.Decimal, ListaPrecio.Importe)
                db.AddInParameter(cmd, "User", DbType.String, ListaPrecio.User)
                db.AddInParameter(cmd, "Fecha_Inicio", DbType.DateTime, ListaPrecio.Fecha)
                db.AddInParameter(cmd, "Moneda", DbType.String, ListaPrecio.Moneda)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, ListaPrecio.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function

    Public Function MantenimientoCanteraListaPrecioFletexMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecioFletexMineral)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.String, ListaPrecio.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
                db.AddInParameter(cmd, "Cod_Mineral", DbType.String, ListaPrecio.CodigoMineral)
                db.AddInParameter(cmd, "Precio", DbType.Decimal, ListaPrecio.Importe)
                db.AddInParameter(cmd, "User", DbType.String, ListaPrecio.User)
                db.AddInParameter(cmd, "Fecha_Inicio", DbType.DateTime, ListaPrecio.Fecha)
                db.AddInParameter(cmd, "Moneda", DbType.String, ListaPrecio.Moneda)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, ListaPrecio.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function
    Public Function Validar_Duplicidad_CanteraListaPrecio(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecio)

        Try
            db.AddInParameter(cmd, "ID", DbType.String, ListaPrecio.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Equipo", DbType.String, ListaPrecio.Cod_Equipo)
            db.AddInParameter(cmd, "Cod_Proveedor", DbType.String, ListaPrecio.CodigoProveedor)
            db.AddInParameter(cmd, "Fecha_Inicio", DbType.DateTime, ListaPrecio.Fecha)
            db.AddInParameter(cmd, "Moneda", DbType.String, ListaPrecio.Moneda)
            db.AddInParameter(cmd, "Tipo_Periodo", DbType.String, ListaPrecio.Periodo)
            db.AddInParameter(cmd, "Tipo_Equipo", DbType.String, ListaPrecio.NombreTipo)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, 5)
            IntRes = db.ExecuteScalar(cmd)

            If IntRes <= 0 Then
                ETResultado.Realizo = False
            Else
                ETResultado.Realizo = True
            End If

        Catch Err As Exception
            ETResultado.Realizo = False
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ETResultado
    End Function
    Public Function Validar_Duplicidad_CanteraListaPrecioFlete(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecioFlete)

        Try
            db.AddInParameter(cmd, "ID", DbType.String, ListaPrecio.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Proveedor", DbType.String, ListaPrecio.CodigoProveedor)
            db.AddInParameter(cmd, "Fecha_Inicio", DbType.DateTime, ListaPrecio.Fecha)
            db.AddInParameter(cmd, "Moneda", DbType.String, ListaPrecio.Moneda)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, 5)
            IntRes = db.ExecuteScalar(cmd)

            If IntRes <= 0 Then
                ETResultado.Realizo = False
            Else
                ETResultado.Realizo = True
            End If

        Catch Err As Exception
            ETResultado.Realizo = False
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ETResultado
    End Function

    Public Function Validar_Duplicidad_CanteraListaPrecioFletexMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecioFletexMineral)

        Try
            db.AddInParameter(cmd, "ID", DbType.String, ListaPrecio.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Mineral", DbType.String, ListaPrecio.CodigoMineral)
            db.AddInParameter(cmd, "Fecha_Inicio", DbType.DateTime, ListaPrecio.Fecha)
            db.AddInParameter(cmd, "Moneda", DbType.String, ListaPrecio.Moneda)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, 5)
            IntRes = db.ExecuteScalar(cmd)

            If IntRes <= 0 Then
                ETResultado.Realizo = False
            Else
                ETResultado.Realizo = True
            End If

        Catch Err As Exception
            ETResultado.Realizo = False
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ETResultado
    End Function

    Public Function ConsultarCanteraListaPrecio(ByVal ListaPrecio As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecio)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, ListaPrecio.CodCia)
            db.AddInParameter(cmd, "Cod_Equipo", DbType.String, ListaPrecio.Cod_Equipo)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, ListaPrecio.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Cod_Equipo = dr.GetString(dr.GetOrdinal("CodigoEquipo"))
                        .NombreEquipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Precio"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                        .Tipo = dr.GetString(dr.GetOrdinal("Tipo"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Tercero = dr.GetBoolean(dr.GetOrdinal("Tercero"))
                        .CodigoProveedor = dr.GetString(dr.GetOrdinal("CodigoProveedor"))
                        .Proveedor = dr.GetString(dr.GetOrdinal("Proveedor"))
                        .NombreTipo = dr.GetString(dr.GetOrdinal("TipoEquipo"))
                        .Hora = dr.GetDecimal(dr.GetOrdinal("HorasMin"))
                        .TipoPerMin = dr.GetString(dr.GetOrdinal("Tipo_PerMin"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function ConsultarCanteraListaPrecioFlete(ByVal ListaPrecio As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecioFlete)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, ListaPrecio.CodCia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, ListaPrecio.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Precio"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .CodigoProveedor = dr.GetString(dr.GetOrdinal("CodigoProveedor"))
                        .Proveedor = dr.GetString(dr.GetOrdinal("Proveedor"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function ConsultarCanteraListaPrecioFletexMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListaPrecioFletexMineral)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, ListaPrecio.CodCia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, ListaPrecio.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Precio"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .CodigoMineral = dr.GetString(dr.GetOrdinal("CodigoMineral"))
                        .Mineral = dr.GetString(dr.GetOrdinal("Mineral"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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


    '   ****    CANTERA -   DEPRECIACION        ****
    Public Function MantenimientoCanteraDepreciacion(ByVal DepreciacionEquipo As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DepreciacionEquipo)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.String, DepreciacionEquipo.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, DepreciacionEquipo.CodigoCantera)
                db.AddInParameter(cmd, "Tipo_Equipo", DbType.String, DepreciacionEquipo.Tipo)
                db.AddInParameter(cmd, "Cod_Equipo", DbType.String, DepreciacionEquipo.Cod_Equipo)
                db.AddInParameter(cmd, "Ano", DbType.Int32, DepreciacionEquipo.Ano)
                db.AddInParameter(cmd, "Moneda", DbType.String, DepreciacionEquipo.Moneda)
                db.AddInParameter(cmd, "Importe", DbType.Decimal, DepreciacionEquipo.Importe)
                db.AddInParameter(cmd, "Archivo1", DbType.String, DepreciacionEquipo.Archivo1)
                db.AddInParameter(cmd, "Archivo2", DbType.String, DepreciacionEquipo.Archivo2)
                db.AddInParameter(cmd, "Archivo3", DbType.String, DepreciacionEquipo.Archivo3)
                db.AddInParameter(cmd, "User", DbType.String, DepreciacionEquipo.User)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, DepreciacionEquipo.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                If Not String.IsNullOrEmpty(DepreciacionEquipo.Archivo1) And (Mid(DepreciacionEquipo.Archivo1, 1, 2) <> "\\") Then
                    Dim xword As Integer = 0
                    Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                    db.AddInParameter(cmd1, "Opcion", DbType.Int32, 5)
                    Dim ds As DataSet = Nothing
                    ds = New DataSet
                    Dim Tabla As DataTable
                    Tabla = New DataTable

                    ds = New DataSet
                    ds = db.ExecuteDataSet(cmd1, Trans)
                    Tabla = New DataTable
                    Tabla = ds.Tables(0).Copy

                    xword = Tabla.Rows(0).Item("Numero")

                    Dim Ruta_Destino_Word As String = "\\Server03\siscomacsa$\Documentos_Minas\doc" & xword & ".doc"
                    My.Computer.FileSystem.CopyFile(DepreciacionEquipo.Archivo1, Ruta_Destino_Word, True)

                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.DepreciacionEquipo)
                    db.AddInParameter(cmd2, "Opcion", DbType.Int32, 5)
                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd2, "ID", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd2, "Archivo1", DbType.String, Ruta_Destino_Word)

                    IntRes = db.ExecuteNonQuery(cmd2, Trans)
                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If


                If Not String.IsNullOrEmpty(DepreciacionEquipo.Archivo2) And (Mid(DepreciacionEquipo.Archivo2, 1, 2) <> "\\") Then
                    Dim xword1 As Integer = 0
                    Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                    db.AddInParameter(cmd3, "Opcion", DbType.Int32, 5)
                    Dim ds As DataSet = Nothing
                    ds = New DataSet
                    Dim Tabla As DataTable
                    Tabla = New DataTable

                    ds = New DataSet
                    ds = db.ExecuteDataSet(cmd3, Trans)
                    Tabla = New DataTable
                    Tabla = ds.Tables(0).Copy

                    xword1 = Tabla.Rows(0).Item("Numero")

                    Dim Ruta_Destino_Word2 As String = "\\Server03\siscomacsa$\Documentos_Minas\doc" & xword1 & ".doc"
                    My.Computer.FileSystem.CopyFile(DepreciacionEquipo.Archivo2, Ruta_Destino_Word2, True)

                    Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.DepreciacionEquipo)
                    db.AddInParameter(cmd4, "Opcion", DbType.Int32, 6)
                    db.AddInParameter(cmd4, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd4, "ID", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd4, "Archivo2", DbType.String, Ruta_Destino_Word2)

                    IntRes = db.ExecuteNonQuery(cmd4, Trans)
                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If

                If Not String.IsNullOrEmpty(DepreciacionEquipo.Archivo3) And (Mid(DepreciacionEquipo.Archivo3, 1, 2) <> "\\") Then
                    Dim xword2 As Integer = 0
                    Dim cmd5 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                    db.AddInParameter(cmd5, "Opcion", DbType.Int32, 5)
                    Dim ds As DataSet = Nothing
                    ds = New DataSet
                    Dim Tabla As DataTable
                    Tabla = New DataTable

                    ds = New DataSet
                    ds = db.ExecuteDataSet(cmd5, Trans)
                    Tabla = New DataTable
                    Tabla = ds.Tables(0).Copy

                    xword2 = Tabla.Rows(0).Item("Numero")

                    Dim Ruta_Destino_Word3 As String = "\\Server03\siscomacsa$\Documentos_Minas\doc" & xword2 & ".doc"
                    My.Computer.FileSystem.CopyFile(DepreciacionEquipo.Archivo3, Ruta_Destino_Word3, True)

                    Dim cmd6 As DbCommand = db.GetStoredProcCommand(usp_RAL.DepreciacionEquipo)
                    db.AddInParameter(cmd6, "Opcion", DbType.Int32, 7)
                    db.AddInParameter(cmd6, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd6, "ID", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd6, "Archivo3", DbType.String, Ruta_Destino_Word3)

                    IntRes = db.ExecuteNonQuery(cmd6, Trans)
                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If


                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function

    Public Function ListarCanteraDepreciacion(ByVal CanteraDepreciacion As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.DepreciacionEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, CanteraDepreciacion.CodCia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, CanteraDepreciacion.CodigoCantera)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, CanteraDepreciacion.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .NombreTipo = dr.GetString(dr.GetOrdinal("TipoEquipo"))
                        .Cod_Equipo = dr.GetString(dr.GetOrdinal("CodigoEquipo"))
                        .NombreEquipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Ano = dr.GetInt32(dr.GetOrdinal("Ano"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Importe"))
                        .Archivo1 = dr.GetString(dr.GetOrdinal("Archivo1"))
                        .Archivo2 = dr.GetString(dr.GetOrdinal("Archivo2"))
                        .Archivo3 = dr.GetString(dr.GetOrdinal("Archivo3"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    '   ****    CANTERA -   COSTO AUTORIZACION  ****

    Public Function ConsultarCanteraCostoAutorizacionMensual(ByVal Autorizacion As ETCanteraCosteo) As Double

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CostoAutorizacion)
        Dim lResult As Double = 0

        Try

            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Autorizacion.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Autorizacion.CodCia)
            db.AddInParameter(cmd, "Ano", DbType.Int32, Autorizacion.Ano)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Autorizacion.Mes)
            db.AddInParameter(cmd, "Moneda", DbType.String, Autorizacion.Moneda)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, Autorizacion.Opcion)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

    Public Function ConsultarCanteraCostoAutorizacion(ByVal CostoAutorizacion As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CostoAutorizacion)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, CostoAutorizacion.CodCia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, CostoAutorizacion.CodigoCantera)
            db.AddInParameter(cmd, "Ano", DbType.Int32, CostoAutorizacion.Ano)
            db.AddInParameter(cmd, "Mes", DbType.Int16, CostoAutorizacion.Mes)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, CostoAutorizacion.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Ano = dr.GetInt32(dr.GetOrdinal("Ano"))
                        .Mes = dr.GetInt16(dr.GetOrdinal("Mes"))
                        .MesName = dr.GetString(dr.GetOrdinal("MesName"))
                        .Glosa = dr.GetString(dr.GetOrdinal("Glosa"))
                        .Tipo = dr.GetString(dr.GetOrdinal("Tipo"))
                        .NombreTipo = dr.GetString(dr.GetOrdinal("NombreTipo"))
                        .Cod_Glosa = dr.GetInt32(dr.GetOrdinal("Cod_Glosa"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Importe"))
                        .Importe2 = dr.GetDecimal(dr.GetOrdinal("ImporteMensual"))
                        .Importe3 = dr.GetDecimal(dr.GetOrdinal("ImporteTramite"))
                        .Archivo1 = dr.GetString(dr.GetOrdinal("Archivo1"))
                        .Archivo2 = dr.GetString(dr.GetOrdinal("Archivo2"))
                        .Archivo3 = dr.GetString(dr.GetOrdinal("Archivo3"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCanteraCostoAutorizacion(ByVal CostoAutorizacion As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CostoAutorizacion)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.String, CostoAutorizacion.ID)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, CostoAutorizacion.CodigoCantera)
                db.AddInParameter(cmd, "Ano", DbType.Int32, CostoAutorizacion.Ano)
                db.AddInParameter(cmd, "Mes", DbType.Int16, CostoAutorizacion.Mes)
                db.AddInParameter(cmd, "Moneda", DbType.String, CostoAutorizacion.Moneda)
                db.AddInParameter(cmd, "Importe", DbType.Decimal, CostoAutorizacion.Importe)
                db.AddInParameter(cmd, "ImporteTramite", DbType.Decimal, CostoAutorizacion.Importe3)
                db.AddInParameter(cmd, "Glosa", DbType.Int32, CostoAutorizacion.Cod_Glosa)
                db.AddInParameter(cmd, "Archivo1", DbType.String, CostoAutorizacion.Archivo1)
                db.AddInParameter(cmd, "Archivo2", DbType.String, CostoAutorizacion.Archivo2)
                db.AddInParameter(cmd, "Archivo3", DbType.String, CostoAutorizacion.Archivo3)
                db.AddInParameter(cmd, "Tipo", DbType.String, CostoAutorizacion.Tipo)
                db.AddInParameter(cmd, "User", DbType.String, CostoAutorizacion.User)
                db.AddOutParameter(cmd, "Mensaje", DbType.String, 10)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, CostoAutorizacion.Opcion)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                ETResultado.Mensaje = Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                If IntRes = -1 Then
                    Err.Raise(10)
                End If

                If Not String.IsNullOrEmpty(CostoAutorizacion.Archivo1) And (Mid(CostoAutorizacion.Archivo1, 1, 2) <> "\\") Then
                    Dim xword As Integer = 0
                    Dim cmd1 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                    db.AddInParameter(cmd1, "Opcion", DbType.Int32, 5)
                    Dim ds As DataSet = Nothing
                    ds = New DataSet
                    Dim Tabla As DataTable
                    Tabla = New DataTable

                    ds = New DataSet
                    ds = db.ExecuteDataSet(cmd1, Trans)
                    Tabla = New DataTable
                    Tabla = ds.Tables(0).Copy

                    xword = Tabla.Rows(0).Item("Numero")

                    Dim Ruta_Destino_Word As String = "\\Server03\siscomacsa$\Documentos_Minas\doc" & xword & ".doc"
                    My.Computer.FileSystem.CopyFile(CostoAutorizacion.Archivo1, Ruta_Destino_Word, True)

                    Dim cmd2 As DbCommand = db.GetStoredProcCommand(usp_RAL.CostoAutorizacion)
                    db.AddInParameter(cmd2, "Opcion", DbType.Int32, 5)
                    db.AddInParameter(cmd2, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd2, "ID", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd2, "Archivo1", DbType.String, Ruta_Destino_Word)

                    IntRes = db.ExecuteNonQuery(cmd2, Trans)
                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If


                If Not String.IsNullOrEmpty(CostoAutorizacion.Archivo2) And (Mid(CostoAutorizacion.Archivo2, 1, 2) <> "\\") Then
                    Dim xword1 As Integer = 0
                    Dim cmd3 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                    db.AddInParameter(cmd3, "Opcion", DbType.Int32, 5)
                    Dim ds As DataSet = Nothing
                    ds = New DataSet
                    Dim Tabla As DataTable
                    Tabla = New DataTable

                    ds = New DataSet
                    ds = db.ExecuteDataSet(cmd3, Trans)
                    Tabla = New DataTable
                    Tabla = ds.Tables(0).Copy

                    xword1 = Tabla.Rows(0).Item("Numero")

                    Dim Ruta_Destino_Word2 As String = "\\Server03\siscomacsa$\Documentos_Minas\doc" & xword1 & ".doc"
                    My.Computer.FileSystem.CopyFile(CostoAutorizacion.Archivo2, Ruta_Destino_Word2, True)

                    Dim cmd4 As DbCommand = db.GetStoredProcCommand(usp_RAL.CostoAutorizacion)
                    db.AddInParameter(cmd4, "Opcion", DbType.Int32, 6)
                    db.AddInParameter(cmd4, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd4, "ID", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd4, "Archivo2", DbType.String, Ruta_Destino_Word2)

                    IntRes = db.ExecuteNonQuery(cmd4, Trans)
                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If

                If Not String.IsNullOrEmpty(CostoAutorizacion.Archivo3) And (Mid(CostoAutorizacion.Archivo3, 1, 2) <> "\\") Then
                    Dim xword2 As Integer = 0
                    Dim cmd5 As DbCommand = db.GetStoredProcCommand(usp_RAL.Doc_Pedido)
                    db.AddInParameter(cmd5, "Opcion", DbType.Int32, 5)
                    Dim ds As DataSet = Nothing
                    ds = New DataSet
                    Dim Tabla As DataTable
                    Tabla = New DataTable

                    ds = New DataSet
                    ds = db.ExecuteDataSet(cmd5, Trans)
                    Tabla = New DataTable
                    Tabla = ds.Tables(0).Copy

                    xword2 = Tabla.Rows(0).Item("Numero")

                    Dim Ruta_Destino_Word3 As String = "\\Server03\siscomacsa$\Documentos_Minas\doc" & xword2 & ".doc"
                    My.Computer.FileSystem.CopyFile(CostoAutorizacion.Archivo3, Ruta_Destino_Word3, True)

                    Dim cmd6 As DbCommand = db.GetStoredProcCommand(usp_RAL.CostoAutorizacion)
                    db.AddInParameter(cmd6, "Opcion", DbType.Int32, 7)
                    db.AddInParameter(cmd6, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd6, "ID", DbType.String, ETResultado.Mensaje)
                    db.AddInParameter(cmd6, "Archivo3", DbType.String, Ruta_Destino_Word3)

                    IntRes = db.ExecuteNonQuery(cmd6, Trans)
                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                End If


                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function


    Public Function ConsultarCanteraContratista(ByVal Contratista As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
            db.AddInParameter(cmd, "Periodo", DbType.Date, Contratista.Fecha.Date)
            db.AddInParameter(cmd, "Esquema", DbType.String, Contratista.Esquema)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Contratista.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .ID_Castigo = dr.GetString(dr.GetOrdinal("ID_Castigo"))
                        .Periodo = dr.GetString(dr.GetOrdinal("Periodo"))
                        .CodigoProveedor = dr.GetString(dr.GetOrdinal("Cod_Prov"))
                        .Proveedor = dr.GetString(dr.GetOrdinal("Proveedor"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("Cod_Cantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .CodEmpleado = dr.GetString(dr.GetOrdinal("PlaCod"))
                        .Empleado = dr.GetString(dr.GetOrdinal("Contratista"))
                        .Esquema = dr.GetString(dr.GetOrdinal("Esquema"))
                        .TipoTrabajo = dr.GetString(dr.GetOrdinal("TipoBoleta"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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

    Public Function MantenimientoCanteraContratista(ByVal Contratista As ETCanteraCosteo, ByVal Billete As DataTable, ByVal Personal As DataTable, ByVal Billete_Castigo As DataTable) As ETResultado
        Dim IntRes As String = String.Empty
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
                db.AddInParameter(cmd, "ID_Castigo", DbType.Int32, Val(Contratista.ID_Castigo))
                db.AddInParameter(cmd, "Periodo", DbType.Date, Contratista.Fecha.Date)
                db.AddInParameter(cmd, "Cod_Prov", DbType.String, Contratista.CodigoProveedor)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Contratista.CodigoCantera)
                db.AddInParameter(cmd, "PlaCod", DbType.String, Contratista.CodEmpleado)
                db.AddInParameter(cmd, "Esquema", DbType.String, Contratista.Esquema)
                db.AddInParameter(cmd, "TipoBoleta", DbType.String, Contratista.TipoTrabajo)
                db.AddInParameter(cmd, "User", DbType.String, Contratista.User)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Contratista.Opcion)

                IntRes = db.ExecuteScalar(cmd, Trans)

                If Billete IsNot Nothing Then
                    If Billete.Rows.Count > 0 Then
                        Dim dmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Billete)
                        db.AddInParameter(dmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                        db.AddInParameter(dmd, "ID", DbType.Int32, Val(IntRes))
                        db.AddInParameter(dmd, "User", DbType.String, Contratista.User)
                        db.AddInParameter(dmd, "Opcion", DbType.Int16, 2)
                        db.ExecuteNonQuery(dmd, Trans)
                    End If

                    For Each xRow As DataRow In Billete.Rows
                        If xRow.Item("Action") = True Then
                            Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Billete)
                            db.AddInParameter(xmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                            db.AddInParameter(xmd, "ID", DbType.Int32, Val(IntRes))
                            db.AddInParameter(xmd, "Tipo_Doc", DbType.String, xRow.Item("Tipo_Doc"))
                            db.AddInParameter(xmd, "NumDoc", DbType.String, xRow.Item("NroBillete"))
                            db.AddInParameter(xmd, "Item", DbType.String, xRow.Item("Item"))
                            db.AddInParameter(xmd, "Cod_MatPrima", DbType.String, xRow.Item("Cod_MatPrima"))
                            db.AddInParameter(xmd, "Contratista", DbType.String, Contratista.CodEmpleado)
                            db.AddInParameter(xmd, "Castigo", DbType.Double, xRow.Item("Castigo"))
                            db.AddInParameter(xmd, "User", DbType.String, Contratista.User)
                            db.AddInParameter(xmd, "Opcion", DbType.Int16, 1)
                            db.ExecuteNonQuery(xmd, Trans)
                        End If
                    Next
                End If

                If Billete_Castigo IsNot Nothing Then
                    If Billete_Castigo.Rows.Count > 0 Then
                        Dim dcmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Billete_Castigo)
                        db.AddInParameter(dcmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                        db.AddInParameter(dcmd, "ID", DbType.Int32, Val(Contratista.ID_Castigo))
                        db.AddInParameter(dcmd, "User", DbType.String, Contratista.User)
                        db.AddInParameter(dcmd, "Opcion", DbType.Int16, 2)
                        db.ExecuteNonQuery(dcmd, Trans)
                    End If

                    For Each xRow As DataRow In Billete_Castigo.Rows
                        If xRow.Item("Action") = True Then
                            Dim cxmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Billete_Castigo)
                            db.AddInParameter(cxmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                            db.AddInParameter(cxmd, "ID", DbType.Int32, Val(Contratista.ID_Castigo))
                            db.AddInParameter(cxmd, "Tipo_Doc", DbType.String, xRow.Item("Tipo_Doc"))
                            db.AddInParameter(cxmd, "NumDoc", DbType.String, xRow.Item("NroBillete"))
                            db.AddInParameter(cxmd, "Item", DbType.String, xRow.Item("Item"))
                            db.AddInParameter(cxmd, "Cod_MatPrima", DbType.String, xRow.Item("Cod_MatPrima"))
                            db.AddInParameter(cxmd, "Contratista", DbType.String, Contratista.CodEmpleado)
                            db.AddInParameter(cxmd, "Castigo", DbType.Double, xRow.Item("Castigo"))
                            db.AddInParameter(cxmd, "User", DbType.String, Contratista.User)
                            db.AddInParameter(cxmd, "Opcion", DbType.Int16, 1)
                            db.ExecuteNonQuery(cxmd, Trans)
                        End If
                    Next
                End If


                If Personal IsNot Nothing Then
                    If Personal.Rows.Count > 0 Then
                        Dim emd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Personal)
                        db.AddInParameter(emd, "Cod_Cia", DbType.String, Contratista.CodCia)
                        db.AddInParameter(emd, "ID", DbType.Int32, Val(IntRes))
                        db.AddInParameter(emd, "User", DbType.String, Contratista.User)
                        db.AddInParameter(emd, "Opcion", DbType.Int16, 2)
                        db.ExecuteNonQuery(emd, Trans)
                    End If
                    For Each yRow As DataRow In Personal.Rows
                        If yRow.Item("Action") = True Then
                            Dim pmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Personal)
                            db.AddInParameter(pmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                            db.AddInParameter(pmd, "ID", DbType.Int32, Val(IntRes))
                            db.AddInParameter(pmd, "PlaCod", DbType.String, yRow.Item("PlaCod"))
                            db.AddInParameter(pmd, "User", DbType.String, Contratista.User)
                            db.AddInParameter(pmd, "Opcion", DbType.Int16, 1)
                            db.ExecuteNonQuery(pmd, Trans)
                        End If
                    Next

                End If

                ETResultado.Mensaje = IntRes 'Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function

    Public Function Validar_Duplicidad_CanteraContratista(ByVal Contratista As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
            db.AddInParameter(cmd, "Periodo", DbType.Date, Contratista.Fecha.Date)
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Contratista.CodigoProveedor)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, Contratista.CodigoCantera)
            db.AddInParameter(cmd, "PlaCod", DbType.String, Contratista.CodEmpleado)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Contratista.Opcion)
            IntRes = db.ExecuteScalar(cmd)

            If IntRes <= 0 Then
                ETResultado.Realizo = False
            Else
                ETResultado.Realizo = True
            End If

        Catch Err As Exception
            ETResultado.Realizo = False
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ETResultado
    End Function

    Public Function Consultar_CanteraContratista_Billete(ByVal Contratista As ETCanteraCosteo) As DataSet
        Dim ds As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Consultar_CanteraContratista_Billete)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
            db.AddInParameter(cmd, "Cantera", DbType.String, Contratista.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Contratista.CodigoProveedor)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Contratista.FechaInicio)
            db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Contratista.FechaFin)

            ds = db.ExecuteDataSet(cmd)


        Catch Err As Exception
            ds = Nothing
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ds
    End Function

    Public Function Consultar_CanteraContratista_Personal(ByVal Contratista As ETCanteraCosteo) As DataSet
        Dim ds As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Consultar_CanteraContratista_Personal)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Contratista.CodigoProveedor)
            db.AddInParameter(cmd, "Fecha", DbType.Date, Contratista.Fecha)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, Contratista.Opcion)
            ds = db.ExecuteDataSet(cmd)


        Catch Err As Exception
            ds = Nothing
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return ds
    End Function

    Public Function Consultar_CanteraContratista_Personal_Faltas(ByVal Contratista As ETCanteraCosteo) As DataSet
        Dim ds As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Consultar_CanteraContratista_Personal_Faltas)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
            db.AddInParameter(cmd, "PlaCod", DbType.String, Contratista.CodEmpleado)
            ' db.AddInParameter(cmd, "Opcion", DbType.Int16, Contratista.Opcion)
            ds = db.ExecuteDataSet(cmd)


        Catch Err As Exception
            ds = Nothing
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ds
    End Function

    Public Function MantenimientoCanteraContratista_Faltas(ByVal Contratista As ETCanteraCosteo, ByVal Anular As List(Of ETPersonal), ByVal Faltas As List(Of ETPersonal)) As ETResultado
        Dim IntRes As String = String.Empty
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                If Contratista.Opcion = 3 Then
                    Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Personal_Faltas)
                    db.AddInParameter(xmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                    db.AddInParameter(xmd, "ID", DbType.Int32, Val(Contratista.ID))
                    db.AddInParameter(xmd, "User", DbType.String, Contratista.User)
                    db.AddInParameter(xmd, "Tipo", DbType.Int16, Contratista.Opcion)

                    db.ExecuteNonQuery(xmd, Trans)

                End If

                If Anular IsNot Nothing Then
                    If Anular.Count > 0 Then
                        For Each dRow As ETPersonal In Anular
                            Dim dmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Personal_Faltas)
                            db.AddInParameter(dmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                            db.AddInParameter(dmd, "ID", DbType.Int32, Val(Contratista.ID))
                            db.AddInParameter(dmd, "PlaCod", DbType.String, dRow.CodPersonal)
                            db.AddInParameter(dmd, "User", DbType.String, Contratista.User)
                            db.AddInParameter(dmd, "Opcion", DbType.Int16, 2)
                            db.ExecuteNonQuery(dmd, Trans)
                        Next
                    End If
                End If

                If Faltas IsNot Nothing Then
                    If Faltas.Count > 0 Then
                        For Each xRow As ETPersonal In Faltas
                            Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Personal_Faltas)
                            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
                            db.AddInParameter(cmd, "PlaCod", DbType.String, xRow.CodPersonal)
                            db.AddInParameter(cmd, "Serie", DbType.String, xRow.Serie_Guia)
                            db.AddInParameter(cmd, "NroGuia", DbType.String, xRow.Nro_Guia)
                            db.AddInParameter(cmd, "User", DbType.String, Contratista.User)
                            db.AddInParameter(cmd, "Opcion", DbType.Int16, 1)
                            db.ExecuteNonQuery(cmd, Trans)
                        Next
                    End If
                End If


                ETResultado.Mensaje = Contratista.ID 'Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function

    Public Function Validar_Duplicidad_CanteraContratistaListaPrecioMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_ListaPrecioMineral)

        Try
            db.AddInParameter(cmd, "ID", DbType.String, ListaPrecio.ID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Proveedor", DbType.String, ListaPrecio.CodigoProveedor)
            db.AddInParameter(cmd, "Cod_Mineral", DbType.String, ListaPrecio.CodigoMineral)
            db.AddInParameter(cmd, "Vigencia", DbType.DateTime, ListaPrecio.Fecha)
            db.AddInParameter(cmd, "Moneda", DbType.String, ListaPrecio.Moneda)
            db.AddInParameter(cmd, "Opcion", DbType.Int16, 4)
            IntRes = db.ExecuteScalar(cmd)

            If IntRes <= 0 Then
                ETResultado.Realizo = False
            Else
                ETResultado.Realizo = True
            End If

        Catch Err As Exception
            ETResultado.Realizo = False
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ETResultado
    End Function

    Public Function MantenimientoCanteraContratista_ListaPrecioMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_ListaPrecioMineral)

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "ID", DbType.Int32, Val(ListaPrecio.ID))
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Cod_Cantera", DbType.String, ListaPrecio.CodigoCantera)
                db.AddInParameter(cmd, "Cod_Proveedor", DbType.String, ListaPrecio.CodigoProveedor)
                db.AddInParameter(cmd, "Cod_Mineral", DbType.String, ListaPrecio.CodigoMineral)
                db.AddInParameter(cmd, "Precio", DbType.Decimal, ListaPrecio.Importe)
                db.AddInParameter(cmd, "Bonificacion", DbType.Decimal, ListaPrecio.Importe2)
                db.AddInParameter(cmd, "User", DbType.String, ListaPrecio.User)
                db.AddInParameter(cmd, "Vigencia", DbType.DateTime, ListaPrecio.Fecha)
                db.AddInParameter(cmd, "Moneda", DbType.String, ListaPrecio.Moneda)
                db.AddInParameter(cmd, "Opcion", DbType.Int16, ListaPrecio.Opcion)
                If ListaPrecio.Opcion = 2 Then
                    IntRes = db.ExecuteNonQuery(cmd, Trans)

                    If IntRes = -1 Then
                        Err.Raise(10)
                    End If

                Else
                    ETResultado.Mensaje = db.ExecuteScalar(cmd, Trans)
                End If

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function

    Public Function ConsultarCanteraContratista_ListaPrecioMineral(ByVal ListaPrecio As ETCanteraCosteo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_ListaPrecioMineral)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, ListaPrecio.CodCia)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, ListaPrecio.Opcion)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    With Entidad.CanteraCosteo
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Importe = dr.GetDecimal(dr.GetOrdinal("Precio"))
                        .Importe2 = dr.GetDecimal(dr.GetOrdinal("Bonificacion"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .CodigoCantera = dr.GetString(dr.GetOrdinal("CodigoCantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("Cantera"))
                        .CodigoMineral = dr.GetString(dr.GetOrdinal("CodigoMineral"))
                        .Mineral = dr.GetString(dr.GetOrdinal("Mineral"))
                        .CodigoProveedor = dr.GetString(dr.GetOrdinal("CodigoProveedor"))
                        .Proveedor = dr.GetString(dr.GetOrdinal("Proveedor"))
                    End With
                    lResult.Ls_CanteraCosteo.Add(Entidad.CanteraCosteo)
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


    Public Function Generar_CanteraContratista_Esquema1(ByVal Contratista As ETCanteraCosteo) As DataSet
        Dim ds As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Generar_CanteraContratista_Esquema1)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
            db.AddInParameter(cmd, "ID_Castigo", DbType.Int32, Val(Contratista.ID_Castigo))
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Contratista.CodigoProveedor)
            db.AddInParameter(cmd, "Fecha", DbType.Date, Contratista.Fecha)
            db.AddInParameter(cmd, "Cantera", DbType.String, Contratista.CodigoCantera)
            ds = db.ExecuteDataSet(cmd)


        Catch Err As Exception
            ds = Nothing
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return ds
    End Function

    Public Function MantenimientoCanteraContratista_Guia_vs_Personal(ByVal Contratista As ETCanteraCosteo, ByVal Anular As List(Of ETPersonal), ByVal Faltas As List(Of ETPersonal)) As ETResultado
        Dim IntRes As String = String.Empty
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                If Contratista.Opcion = 3 Then
                    Dim xmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Personal_Guia)
                    db.AddInParameter(xmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                    db.AddInParameter(xmd, "ID", DbType.Int32, Val(Contratista.ID))
                    db.AddInParameter(xmd, "User", DbType.String, Contratista.User)
                    db.AddInParameter(xmd, "Tipo", DbType.Int16, Contratista.Opcion)

                    db.ExecuteNonQuery(xmd, Trans)

                End If

                If Anular IsNot Nothing Then
                    If Anular.Count > 0 Then
                        For Each dRow As ETPersonal In Anular
                            Dim dmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Personal_Guia)
                            db.AddInParameter(dmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                            db.AddInParameter(dmd, "ID", DbType.Int32, Val(Contratista.ID))
                            db.AddInParameter(dmd, "PlaCod", DbType.String, dRow.CodPersonal)
                            db.AddInParameter(dmd, "User", DbType.String, Contratista.User)
                            db.AddInParameter(dmd, "Opcion", DbType.Int16, 2)
                            db.ExecuteNonQuery(dmd, Trans)
                        Next
                    End If
                End If

                If Faltas IsNot Nothing Then
                    If Faltas.Count > 0 Then
                        For Each xRow As ETPersonal In Faltas
                            Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CanteraContratista_Personal_Guia)
                            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
                            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
                            db.AddInParameter(cmd, "PlaCod", DbType.String, xRow.CodPersonal)
                            db.AddInParameter(cmd, "Serie", DbType.String, xRow.Serie_Guia)
                            db.AddInParameter(cmd, "NroGuia", DbType.String, xRow.Nro_Guia)
                            db.AddInParameter(cmd, "User", DbType.String, Contratista.User)
                            db.AddInParameter(cmd, "Opcion", DbType.Int16, 1)
                            db.ExecuteNonQuery(cmd, Trans)
                        Next
                    End If
                End If


                ETResultado.Mensaje = Contratista.ID 'Convert.ToString(db.GetParameterValue(cmd, "Mensaje"))

                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado
    End Function

    Public Function Consultar_CanteraContratista_Personal_Guia(ByVal Contratista As ETCanteraCosteo) As DataSet
        Dim ds As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Consultar_CanteraContratista_Personal_Guia)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
            db.AddInParameter(cmd, "PlaCod", DbType.String, Contratista.CodEmpleado)
            ' db.AddInParameter(cmd, "Opcion", DbType.Int16, Contratista.Opcion)
            ds = db.ExecuteDataSet(cmd)


        Catch Err As Exception
            ds = Nothing
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ds
    End Function


    Public Function Consultar_CanteraContratista_Billete_Castigo(ByVal Contratista As ETCanteraCosteo) As DataSet
        Dim ds As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim ETResultado As New ETResultado
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.Consultar_CanteraContratista_Billete_Castigo)

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Contratista.CodCia)
            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Contratista.ID))
            db.AddInParameter(cmd, "Cantera", DbType.String, Contratista.CodigoCantera)
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Contratista.CodigoProveedor)

            ds = db.ExecuteDataSet(cmd)


        Catch Err As Exception
            ds = Nothing
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing

        End Try

        Return ds
    End Function

    Public Function MantenimientoAgrupacion(ByVal U As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MANTENIMIENTOAGRUPACION)
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "ID", DbType.String, U.ID)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "DESCRIPCION", DbType.String, U.Descripcion)
                db.AddInParameter(cmd, "USUARIO", DbType.String, U.User)
                db.AddOutParameter(cmd, "CODIGO", DbType.String, 10)
                IntRes = db.ExecuteNonQuery(cmd, Trans)
                If IntRes = -1 Then
                    Err.Raise(10)
                End If
                Trans.Commit()
                Conexion.Close()
                ETResultado.CodAgrupacion = Convert.ToString(db.GetParameterValue(cmd, "CODIGO"))
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function

    Public Function MantenimientoAgrupacionRuma(ByVal U As ETCanteraCosteo) As ETResultado
        Dim IntRes As Integer = -1
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.MANTENIMIENTOAGRUPACIONRUMA)
        Dim ETResultado As New ETResultado

        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "CHECK", DbType.Int32, U.check)
                db.AddInParameter(cmd, "CODAGRUPACION", DbType.String, U.codagrupacion)
                db.AddInParameter(cmd, "CODRUMA", DbType.String, U.codruma)
                db.AddInParameter(cmd, "USUARIO", DbType.String, U.User)

                Dim ds As DataSet = Nothing
                ds = New DataSet
                Dim Tabla As DataTable
                Tabla = New DataTable

                ds = New DataSet
                ds = db.ExecuteDataSet(cmd, Trans)
                Tabla = New DataTable
                Tabla = ds.Tables(0).Copy
                'IntRes = db.ExecuteNonQuery(cmd, Trans)
                If Tabla.Rows.Count <= 0 Then
                    Err.Raise(10)
                End If
                Trans.Commit()
                Conexion.Close()
                ETResultado.Realizo = True

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                ETResultado.Realizo = False
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            End Try

        End Using

        Return ETResultado

    End Function
End Class
