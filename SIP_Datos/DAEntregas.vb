Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient
Public Class DAEntregas

    'Lista de Limites de Solicitudes de Tarjetas de 

    Public Function LimiteLineaCredito(ByVal idTarjetaConsumo As Integer, ByVal IdTipoTarjetaConsumo As Integer) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase()

        'Public Const LimiteLineaCredito25 As String = "USP_LimiteLineaTarjetaCredito25"
        If idTarjetaConsumo <> 0 Then
            Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.LimiteLineaCredito25)

            Try
                db.AddInParameter(cmd, "@IdTarjetaConsumo", DbType.Int32, idTarjetaConsumo)
                db.AddInParameter(cmd, "@IdTipoTarjetaConsumo", DbType.Int32, IdTipoTarjetaConsumo)

                lResult = New ETMyLista

                Using dr As IDataReader = db.ExecuteReader(cmd)

                    While dr.Read
                        Entidad.Entregas = New ETEntregas
                        With Entidad.Entregas
                            .idTarjetaConsumo = dr.GetInt32(dr.GetOrdinal("IdTarjetaConsumo"))
                            .FechaInicioPeriodo = dr.GetDateTime(dr.GetOrdinal("FechaInicioPeriodo"))
                            .FechaFinPeriodo = dr.GetDateTime(dr.GetOrdinal("FechaFinPeriodo"))
                            .DiasPeriodo = dr.GetInt32(dr.GetOrdinal("DiasPeriodo"))
                            .LimiteCredito = dr.GetDecimal(dr.GetOrdinal("LimiteCredito"))
                            .TotalConsumido = dr.GetDecimal(dr.GetOrdinal("TotalConsumido"))
                            .SaldoDisponible = dr.GetDecimal(dr.GetOrdinal("SaldoDisponible"))
                            .EstadoCredito = dr.GetString(dr.GetOrdinal("EstadoCredito"))

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

        Else

            lResult = Nothing


        End If

        Return lResult

    End Function


    Public Function ListarSolicitudes(ByVal Rpt As ETEntregas) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Solicitudes)
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Solicitudes25)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .Estado = dr.GetString(dr.GetOrdinal("estado"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("fechacrea"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Usuario = dr.GetString(dr.GetOrdinal("usuario"))
                        .moneda = dr.GetString(dr.GetOrdinal("moneda"))
                        .flgpermiso = dr.GetInt32(dr.GetOrdinal("flgpermiso"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("fechaaprobacion"))
                        .idTarjetaConsumo = dr.GetInt32(dr.GetOrdinal("id_empleado_tarjetaconsumo"))
                        .idTipoTarjetaConsumo = dr.GetInt32(dr.GetOrdinal("id_tipotarjetaconsumo"))
                        .nroTarjeta = dr.GetString(dr.GetOrdinal("nro_tarjeta"))

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


    Public Function ListarTrabajadorxCodigo(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_TrabajadorCod)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "codigo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        '.NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .bancobeneficiario = dr.GetString(dr.GetOrdinal("pagobanco"))
                        .ctabeneficiario = dr.GetString(dr.GetOrdinal("pagonumcta"))
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

    Public Function ListarAreas() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Areas)
        Dim lResult As ETMyLista = Nothing
        Try
            'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codArea = dr.GetString(dr.GetOrdinal("cod_maestro2"))
                        .Area = dr.GetString(dr.GetOrdinal("descrip"))
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

    Public Function ListarCanteras() As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Canteras)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codCantera = dr.GetString(dr.GetOrdinal("codcantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("descripcion"))
                        .Region = dr.GetString(dr.GetOrdinal("region"))
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

    Public Function ListarProductos() As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarProductos)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodProducto = dr.GetString(dr.GetOrdinal("cod_prod"))
                        .Producto = dr.GetString(dr.GetOrdinal("producto"))
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

    Public Function ListarProductosVTA() As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarProductosVTA)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodProducto = dr.GetString(dr.GetOrdinal("cod_prod"))
                        .Producto = dr.GetString(dr.GetOrdinal("producto"))
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

    Public Function ListarRumas() As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarRumas)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodProducto = dr.GetString(dr.GetOrdinal("cod_ruma"))
                        .Producto = dr.GetString(dr.GetOrdinal("ruma"))
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

    Public Function MantenimientoSolicitud(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                'Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoSolicitud)
                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoSolicitud25)

                db.AddInParameter(cmd, "tipo", DbType.Int16, Rpt.TipoOperacion)
                db.AddInParameter(cmd, "cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "nrosolicitud", DbType.String, Rpt.NumSolicitud)
                db.AddInParameter(cmd, "codtrabajador", DbType.String, Rpt.CodTrabajador)
                db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
                db.AddInParameter(cmd, "motivo", DbType.String, Rpt.Motivo)
                db.AddInParameter(cmd, "fecsalida", DbType.DateTime, Rpt.fechaSalida)
                db.AddInParameter(cmd, "fecretorno", DbType.DateTime, Rpt.fechaRetorno)
                db.AddInParameter(cmd, "codcantera", DbType.String, Rpt.codCantera)
                db.AddInParameter(cmd, "region", DbType.String, Rpt.Region)
                db.AddInParameter(cmd, "total", DbType.Double, Rpt.montoTotal)
                db.AddInParameter(cmd, "estado", DbType.Int32, Rpt.idEstado)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)

                db.AddInParameter(cmd, "moneda", DbType.String, Rpt.moneda)
                db.AddInParameter(cmd, "flgbeneficiario", DbType.String, Rpt.flgbeneficiario)
                db.AddInParameter(cmd, "dnibeneficiario", DbType.String, Rpt.dnibeneficiario)
                db.AddInParameter(cmd, "beneficiario", DbType.String, Rpt.beneficiario)
                db.AddInParameter(cmd, "tipodepobeneficiario", DbType.String, Rpt.tipodepobeneficiario)
                db.AddInParameter(cmd, "bancobeneficiario", DbType.String, Rpt.bancobeneficiario)
                db.AddInParameter(cmd, "ctabeneficiario", DbType.String, Rpt.ctabeneficiario)

                db.AddInParameter(cmd, "idtarjetaconsumo", DbType.Int32, Rpt.idTarjetaConsumo)
                db.AddInParameter(cmd, "idtipotarjetaconsumo", DbType.Int32, Rpt.idTipoTarjetaConsumo)

                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.AddParameter(cmd, "nsolicitud", DbType.String, 8, ParameterDirection.InputOutput, True, 0, 0, "", DataRowVersion.Default, Rpt.NumSolicitud)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                lResult.NumSolicitud = Convert.ToString(db.GetParameterValue(cmd, "nsolicitud"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

                If Rpt.TipoOperacion <> 3 Then ' And Rpt.idEstado = 1 Then
                    For Each Row In Ls_EntregaDetalle

                        Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoSolicitudDeta)
                        If Row.codConcepto.ToString.Trim <> "" Then
                            db.AddInParameter(xmd, "tipo", DbType.Int16, Rpt.TipoOperacion)
                            db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                            If Rpt.TipoOperacion = 1 Then
                                db.AddInParameter(xmd, "numsolicitud", DbType.String, lResult.NumSolicitud)
                            Else
                                db.AddInParameter(xmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
                            End If
                            db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                            db.AddInParameter(xmd, "monto", DbType.Double, Row.montoParcial)
                            db.AddInParameter(xmd, "dias", DbType.Int32, Row.totaldias)
                            db.AddInParameter(xmd, "montototal", DbType.Double, Row.montoTotalParcial)
                            db.AddInParameter(xmd, "total", DbType.Double, Rpt.montoTotal)
                            db.AddInParameter(xmd, "descripcion", DbType.String, Row.Descripcion)
                            db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                            db.ExecuteNonQuery(xmd, Trans)

                            lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                            If lResult.Respuesta <> 0 Then Err.Raise(10)
                        End If
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

    Public Function MantenimientoSolictudCero(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoSolicitudCero)

                db.AddInParameter(cmd, "TIPO", DbType.Int16, Rpt.TipoOperacion)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "NROSOLICITUD", DbType.String, Rpt.NumSolicitud)
                db.AddInParameter(cmd, "CODTRABAJADOR", DbType.String, Rpt.CodTrabajador)
                db.AddInParameter(cmd, "MOTIVO", DbType.String, Rpt.Motivo)
                db.AddInParameter(cmd, "FECSALIDA", DbType.DateTime, Rpt.fechaSalida)
                db.AddInParameter(cmd, "FECRETORNO", DbType.DateTime, Rpt.fechaRetorno)
                db.AddInParameter(cmd, "CODCANTERA", DbType.String, Rpt.codCantera)
                db.AddInParameter(cmd, "REGION", DbType.String, Rpt.Region)
                db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
                db.AddInParameter(cmd, "USERAPRUEBA", DbType.String, Rpt.userlogin)
                db.AddInParameter(cmd, "MONEDA", DbType.String, Rpt.moneda)

                db.AddOutParameter(cmd, "RESPUESTA", DbType.Int16, 10)
                db.AddParameter(cmd, "NSOLICITUD", DbType.String, 8, ParameterDirection.InputOutput, True, 0, 0, "", DataRowVersion.Default, Rpt.NumSolicitud)

                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "RESPUESTA"))
                lResult.NumSolicitud = Convert.ToString(db.GetParameterValue(cmd, "NSOLICITUD"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function SolicitudDetalle(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_SolicitudDetalle)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        .JefeArea = dr.GetString(dr.GetOrdinal("jefeArea"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .fechaSalida = dr.GetDateTime(dr.GetOrdinal("fechacrea"))
                        .fechaRetorno = dr.GetDateTime(dr.GetOrdinal("fec_limite"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .tipoconcepto = dr.GetString(dr.GetOrdinal("concepto"))
                        .montoParcial = dr.GetDecimal(dr.GetOrdinal("monto"))
                        .totaldias = dr.GetInt32(dr.GetOrdinal("dias"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("montototal"))
                        .idEstado = dr.GetInt32(dr.GetOrdinal("estado"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))

                        .moneda = dr.GetString(dr.GetOrdinal("moneda"))

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
    Public Function SolicitudxNumero(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_SolicitudxNumero)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        .JefeArea = dr.GetString(dr.GetOrdinal("jefeArea"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .fechaSalida = dr.GetDateTime(dr.GetOrdinal("fecsalida"))
                        .fechaRetorno = dr.GetDateTime(dr.GetOrdinal("fecretorno"))
                        .codCantera = dr.GetString(dr.GetOrdinal("codcantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("cantera"))
                        .Region = dr.GetString(dr.GetOrdinal("region"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .montoParcial = dr.GetDecimal(dr.GetOrdinal("monto"))
                        .totaldias = dr.GetInt32(dr.GetOrdinal("dias"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("montototal"))
                        .idEstado = dr.GetInt32(dr.GetOrdinal("estado"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))

                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
                        .banco = dr.GetString(dr.GetOrdinal("banco"))
                        .nrocta = dr.GetString(dr.GetOrdinal("nro_cta"))
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
                        '.idTarjetaConsumo = dr.GetInt32(dr.GetOrdinal("idTarjetaconsumo"))


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


    Public Function SolicitudxNumeroTarjetaConsumo(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_SolicitudxNumeroTarjetaConsumo)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        .JefeArea = dr.GetString(dr.GetOrdinal("jefeArea"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .fechaSalida = dr.GetDateTime(dr.GetOrdinal("fecsalida"))
                        .fechaRetorno = dr.GetDateTime(dr.GetOrdinal("fecretorno"))
                        .codCantera = dr.GetString(dr.GetOrdinal("codcantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("cantera"))
                        .Region = dr.GetString(dr.GetOrdinal("region"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        '.codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .montoParcial = dr.GetDecimal(dr.GetOrdinal("monto"))
                        .totaldias = dr.GetInt32(dr.GetOrdinal("dias"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("montototal"))
                        .idEstado = dr.GetInt32(dr.GetOrdinal("estado"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))

                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
                        .banco = dr.GetString(dr.GetOrdinal("banco"))
                        .nrocta = dr.GetString(dr.GetOrdinal("nro_cta"))
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
                        '.idTarjetaConsumo = dr.GetInt32(dr.GetOrdinal("idTarjetaconsumo"))


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


    Public Function UsuarioAprobacion(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_UsuarioAprobacion)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .Usuario = dr.GetString(dr.GetOrdinal("usuario"))
                        .codArea = dr.GetString(dr.GetOrdinal("cod_area"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("fecha_crea"))
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

    Public Function ListarConceptos() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Conceptos)

        Try
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        .tipoconcepto = dr.GetString(dr.GetOrdinal("tipo"))
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

    Public Function ListarConceptosxArea(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_ConceptosArea)

        Try
            db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        .tipoconcepto = dr.GetString(dr.GetOrdinal("tipo"))
                        '<JOSF 26/12/2022>
                        '.flgKilometraje = dr.GetString(dr.GetOrdinal("flg_kilometraje"))
                        '</JOSF 26/12/2022>
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

    Public Function Listar_JefeArea(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_JefeArea)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            db.AddInParameter(cmd, "placod", DbType.String, Rpt.CodTrabajador)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .JefeArea = dr.GetString(dr.GetOrdinal("jefeArea"))
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

    Public Function Listar_ProveedorxRuc(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_ProveedorxRuc)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "nroruc", DbType.String, Rpt.nroruc)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .Razon = dr.GetString(dr.GetOrdinal("RazSoc"))
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

    Public Function MantenimientoLiquidacion(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoLiquidacion)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "idComp", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "fecha", DbType.DateTime, Row.fechaComp)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "razon", DbType.String, Row.Razon)
                    db.AddInParameter(xmd, "codAuxiliar", DbType.String, Row.codAuxiliar)
                    db.AddInParameter(xmd, "codmotivoviaje", DbType.String, Row.codmotivoDetalle)
                    db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                    db.AddInParameter(xmd, "montototal", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "estado", DbType.Int32, Row.idEstado)
                    db.AddInParameter(xmd, "moneda", DbType.String, Row.moneda)
                    db.AddInParameter(xmd, "cambio", DbType.Double, Row.tipocambio)
                    db.AddInParameter(xmd, "montodoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "codarea", DbType.String, Row.codArea)
                    db.AddInParameter(xmd, "codCantera", DbType.String, Row.codCantera)
                    db.AddInParameter(xmd, "codCanteradet", DbType.String, Row.codCanteradet)
                    db.AddInParameter(xmd, "fechasalida", DbType.DateTime, Row.fechaSalida)
                    db.AddInParameter(xmd, "fecharetorno", DbType.DateTime, Row.fechaRetorno)
                    db.AddInParameter(xmd, "region", DbType.String, Row.Region)
                    db.AddInParameter(xmd, "comentario", DbType.String, Row.comentario)
                    db.AddInParameter(xmd, "motivo", DbType.String, Row.Motivo)
                    db.AddInParameter(xmd, "dias", DbType.String, Row.dias)
                    db.AddInParameter(xmd, "personas", DbType.String, Row.personas)
                    db.AddInParameter(xmd, "nfila", DbType.Int32, Row.nfila)
                    db.AddInParameter(xmd, "flgretencion", DbType.Int32, Row.flgretencion)
                    db.AddInParameter(xmd, "usuario", DbType.String, Row.Usuario)
                    db.AddInParameter(xmd, "IDANEXO3", DbType.Int32, Row.IDANEXO3)
                    db.AddInParameter(xmd, "ANEXO3", DbType.String, Row.ANEXO3)
                    db.AddInParameter(xmd, "PLACA_TERCERO", DbType.String, Row.PLACA_TERCERO)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(1) ': Trans.Rollback() : Conexion.Close() : lResult = Nothing
                    'End If
                Next
                'End If

                lResult.Validacion = Boolean.TrueString

                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                lResult = Nothing

            End Try

        End Using

        Return lResult

    End Function

    Public Function Listar_DetalleLiquidacion(ByVal Rpt As ETEntregas) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DetalleLiquidacion)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            Dim saldo As Double
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .fechaComp = dr.GetDateTime(dr.GetOrdinal("fecha"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .Serie = dr.GetString(dr.GetOrdinal("serie"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .Razon = dr.GetString(dr.GetOrdinal("RazSoc"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Concepto"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .codmotivoDetalle = dr.GetString(dr.GetOrdinal("codmotivo"))
                        .motivoDetalle = dr.GetString(dr.GetOrdinal("Motivoviaje"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("montototal"))
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Cantera = dr.GetString(dr.GetOrdinal("cantera"))
                        .TipoOperacion = 2
                        .idComp = dr.GetInt32(dr.GetOrdinal("idComp"))
                        saldo = dr.GetDecimal(dr.GetOrdinal("saldo"))
                        If saldo > 0 Then
                            .montoDevolucion = dr.GetDecimal(dr.GetOrdinal("saldo"))
                            .montoReintegro = 0
                        Else
                            .montoDevolucion = 0
                            .montoReintegro = dr.GetDecimal(dr.GetOrdinal("saldo"))
                        End If

                        If dr.GetString(dr.GetOrdinal("moneda")) = "S" Then
                            .moneda = "S/."
                        ElseIf dr.GetString(dr.GetOrdinal("moneda")) = "D" Then
                            .moneda = "US$"
                        End If
                        .tipocambio = dr.GetDecimal(dr.GetOrdinal("cambio"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        .flgcompra = dr.GetInt32(dr.GetOrdinal("flgcompra"))
                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
                        .banco = dr.GetString(dr.GetOrdinal("banco"))
                        .NumDocdevo = dr.GetString(dr.GetOrdinal("nro_doc"))
                        .comentario = dr.GetString(dr.GetOrdinal("comentario"))
                        .dias = dr.GetInt32(dr.GetOrdinal("dias"))
                        .personas = dr.GetInt32(dr.GetOrdinal("personas"))
                        .nfila = dr.GetInt32(dr.GetOrdinal("nfila"))
                        .flgretencion = dr.GetInt32(dr.GetOrdinal("flgretencion"))
                        .IDANEXO3 = dr.GetInt32(dr.GetOrdinal("IDAUXI3"))
                        .ANEXO3 = dr.GetString(dr.GetOrdinal("AUXI3"))
                        .PLACA_TERCERO = dr.GetString(dr.GetOrdinal("PLACA_TERCERO"))
                        .codTipoDoc = dr.GetString(dr.GetOrdinal("codtipodoc"))
                        .igv = dr.GetDecimal(dr.GetOrdinal("igv"))
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

    Public Function ListarDocumentos() As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Documentos)

        Try
            'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codTipoDoc = dr.GetString(dr.GetOrdinal("codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("flag1"))
                        .flgcompra = dr.GetInt32(dr.GetOrdinal("flgcompra"))
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

    Public Function Listar_Liquidaciones(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If
        'Dim dato_sunat As New sg_consulta_documento_nacional.metodos()
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Liquidaciones)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .Estado = dr.GetString(dr.GetOrdinal("estado"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("fechacrea"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Usuario = dr.GetString(dr.GetOrdinal("usuario"))
                        .moneda = dr.GetString(dr.GetOrdinal("moneda"))
                        .flgpermiso = dr.GetInt32(dr.GetOrdinal("flgpermiso"))
                        .ID = dr.GetInt32(dr.GetOrdinal("id"))
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

    Public Function ListarMotivos() As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Motivos)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codmotivoDetalle = dr.GetString(dr.GetOrdinal("codigo"))
                        .motivoDetalle = dr.GetString(dr.GetOrdinal("descripcion"))
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

    Public Function ConsultaEntregas(ByVal Rpt As ETEntregas) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ConsultaEntregas)
        cmd.CommandTimeout = 0
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Motivo = dr.GetString(dr.GetOrdinal("tipo"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("saldo"))
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

    Public Function ConsultaSaldos(ByVal Rpt As ETEntregas) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ConsultaSaldos)

        Dim FechaString As String = Rpt.Fecha.ToString
        FechaString = Mid(FechaString, 1, 10)
        'Dim XX As String = Rpt.Fecha.ToString("DD/MM/YYYY")
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "FECHA", DbType.String, FechaString)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Motivo = dr.GetString(dr.GetOrdinal("tipo"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("saldo"))
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

    Public Function ConsultaSaldosAprobados(ByVal Rpt As ETEntregas) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ConsultaSaldosAprobados)
        cmd.CommandTimeout = 0
        Dim FechaString As String = Rpt.Fecha.ToString
        FechaString = Mid(FechaString, 1, 10)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "FECHA", DbType.String, FechaString)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Motivo = dr.GetString(dr.GetOrdinal("tipo"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("saldo"))
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

    Public Function ConsultaEntregasDetalle(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CONSULTA_ENTREGAS)
        cmd.CommandTimeout = 60000
        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "TIPO", DbType.Int32, Rpt.Tipo)
            db.AddInParameter(cmd, "CODTRABAJADOR", DbType.String, Rpt.CodTrabajador)
            db.AddInParameter(cmd, "FECHAINI", DbType.Date, Rpt.FechaInicio)
            db.AddInParameter(cmd, "FECHAFIN", DbType.Date, Rpt.FechaTerminacion)
            db.AddInParameter(cmd, "TIPOFILTRO", DbType.String, Rpt.tipofiltro)
            db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "TIPOIMPRESION", DbType.Int32, Rpt.TipoImpresion)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("FECHAEMISION"))
                        .montoParcial = dr.GetDecimal(dr.GetOrdinal("MONTOSOLICITUD"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("MONTOLIQUIDACION"))
                        .Motivo = dr.GetString(dr.GetOrdinal("MOTIVO"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("SALDO"))
                        .moneda = dr.GetString(dr.GetOrdinal("MONEDA"))

                        .tipodeposito = dr.GetString(dr.GetOrdinal("TIPODEPOSITO"))
                        .Cantera = dr.GetString(dr.GetOrdinal("CANTERA"))
                        .dias = dr.GetInt32(dr.GetOrdinal("DIASMOROSIDAD"))

                        '.fechaComp = dr.GetDateTime(dr.GetOrdinal("FECHALIQUIDACION"))
                        '.NumDoc = dr.GetString(dr.GetOrdinal("NUMEROLIQUI"))
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

    Public Function ListarUsuariosAprueba(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If
        'Dim dato_sunat As New sg_consulta_documento_nacional.metodos()
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_UsuariosAprueba)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .Usuario = dr.GetString(dr.GetOrdinal("USUARIO"))
                        .codArea = dr.GetString(dr.GetOrdinal("COD_AREA"))
                        .Area = dr.GetString(dr.GetOrdinal("Area"))
                        .tipoAprobacion = dr.GetString(dr.GetOrdinal("tipoAprobacion"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("ENCARGADO"))
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

    Public Function CargarUsuarios(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Cargar_Usuarios)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "sistema", DbType.String, Rpt.Sistema)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .userlogin = dr.GetString(dr.GetOrdinal("login"))
                        .encargado = dr.GetString(dr.GetOrdinal("encargado"))
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

    Public Function CargarUsuariosAprueba(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CargarUsuariosAprueba)

        Try
            db.AddInParameter(cmd, "CODAREA", DbType.String, Rpt.codArea)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .userlogin = dr.GetString(dr.GetOrdinal("login"))
                        .encargado = dr.GetString(dr.GetOrdinal("encargado"))
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

    Public Function MantenimientoUsuarioAprobacion(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                lResult = New ETEntregas
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoUsuarioAprobacion)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "usuario", DbType.String, Row.userlogin)
                    db.AddInParameter(xmd, "cod_area", DbType.String, Row.codArea)
                    db.AddInParameter(xmd, "usercrea", DbType.String, Row.Usuario)
                    db.AddInParameter(xmd, "tipouser", DbType.Int32, Row.tipoAprobacion)
                    db.AddInParameter(xmd, "check", DbType.Int32, Row.check)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))
                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next

                'Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoUsuarioAprobacion)
                'lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

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

    Public Function CargarPersonal(ByVal Cencos As String) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If
        Dim cmd As DbCommand
        Dim db As Database = DatabaseFactory.CreateDatabase()
        If Cencos = "" Then
            cmd = db.GetStoredProcCommand(SP_ADMINISTRACION.Cargar_Personal)
        Else
            cmd = db.GetStoredProcCommand(SP_ADMINISTRACION.Cargar_Personal_ID)
        End If

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("placod"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .bancobeneficiario = dr.GetString(dr.GetOrdinal("pagobanco"))
                        .ctabeneficiario = dr.GetString(dr.GetOrdinal("pagonumcta"))
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

    Public Function CargarPersonalTarjetaConsumo(ByVal _lchk_tarjeta As Integer) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If
        Dim cmd As DbCommand
        Dim db As Database = DatabaseFactory.CreateDatabase()
        cmd = db.GetStoredProcCommand(SP_ADMINISTRACION.Cargar_Personal_TarjetaConsumo)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("placod"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .bancobeneficiario = dr.GetString(dr.GetOrdinal("pagobanco"))
                        .ctabeneficiario = dr.GetString(dr.GetOrdinal("pagonumcta"))
                        .nro_tarjeta = dr.GetString(dr.GetOrdinal("nro_tarjeta"))
                        '.tipo_tarjeta = dr.GetString(dr.GetOrdinal("tipo_tarjeta"))
                        .cod_banco = dr.GetString(dr.GetOrdinal("cod_banco"))

                        'If _lchk_tarjeta = 2 Then
                        '.saldo_ini = dr.GetDecimal(dr.GetOrdinal("saldo_ini1"))
                        'Else
                        '.saldo_ini = dr.GetDecimal(dr.GetOrdinal("saldo_ini"))
                        'End If
                        .saldo_ini = dr.GetDecimal(dr.GetOrdinal("saldo_ini"))
                        .saldo_ini1 = dr.GetDecimal(dr.GetOrdinal("saldo_ini1"))

                        .idTarjetaConsumo = dr.GetInt32(dr.GetOrdinal("Id"))

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
    Public Function CargarBarbotina() As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.listar_barbotina)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodProducto = dr.GetString(dr.GetOrdinal("cod_prod"))
                        .Producto = dr.GetString(dr.GetOrdinal("descrip"))
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

    Public Function MantenimientoLiquidacionPend(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoLiquidacionPend)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "idComp", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "fecha", DbType.DateTime, Row.fechaComp)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "razon", DbType.String, Row.Razon)
                    db.AddInParameter(xmd, "codAuxiliar", DbType.String, Row.codAuxiliar)
                    db.AddInParameter(xmd, "codmotivoviaje", DbType.String, Row.codmotivoDetalle)
                    db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                    db.AddInParameter(xmd, "montototal", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "estado", DbType.Int32, Row.idEstado)
                    db.AddInParameter(xmd, "moneda", DbType.String, Row.moneda)
                    db.AddInParameter(xmd, "cambio", DbType.Double, Row.tipocambio)
                    db.AddInParameter(xmd, "montodoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "codarea", DbType.String, Row.codArea)
                    db.AddInParameter(xmd, "codCantera", DbType.String, Row.codCantera)
                    db.AddInParameter(xmd, "codCanteradet", DbType.String, Row.codCanteradet)
                    db.AddInParameter(xmd, "fechasalida", DbType.DateTime, Row.fechaSalida)
                    db.AddInParameter(xmd, "fecharetorno", DbType.DateTime, Row.fechaRetorno)
                    db.AddInParameter(xmd, "region", DbType.String, Row.Region)
                    db.AddInParameter(xmd, "comentario", DbType.String, Row.comentario)
                    db.AddInParameter(xmd, "idpendiente", DbType.Int32, Row.ID)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function Listar_DetalleLiquidacionPend(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DetalleLiquidacionPend)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "idPendiente", DbType.Int32, Rpt.ID)
            Dim saldo As Double
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .fechaComp = dr.GetDateTime(dr.GetOrdinal("fecha"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .Serie = dr.GetString(dr.GetOrdinal("serie"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .Razon = dr.GetString(dr.GetOrdinal("RazSoc"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Concepto"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .codmotivoDetalle = dr.GetString(dr.GetOrdinal("codmotivo"))
                        .motivoDetalle = dr.GetString(dr.GetOrdinal("Motivoviaje"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("montototal"))
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Cantera = dr.GetString(dr.GetOrdinal("cantera"))
                        .TipoOperacion = 2
                        .idComp = dr.GetInt32(dr.GetOrdinal("idComp"))
                        saldo = dr.GetDecimal(dr.GetOrdinal("saldo"))
                        If saldo > 0 Then
                            .montoDevolucion = dr.GetDecimal(dr.GetOrdinal("saldo"))
                            .montoReintegro = 0
                        Else
                            .montoDevolucion = 0
                            .montoReintegro = dr.GetDecimal(dr.GetOrdinal("saldo"))
                        End If
                        If dr.GetString(dr.GetOrdinal("moneda")) = "S" Then
                            .moneda = "S/."
                        ElseIf dr.GetString(dr.GetOrdinal("moneda")) = "D" Then
                            .moneda = "US$"
                        End If
                        .tipocambio = dr.GetDecimal(dr.GetOrdinal("cambio"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        .flgcompra = dr.GetInt32(dr.GetOrdinal("flgcompra"))

                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
                        .banco = dr.GetString(dr.GetOrdinal("banco"))
                        .NumDocdevo = dr.GetString(dr.GetOrdinal("nro_doc"))
                        .comentario = dr.GetString(dr.GetOrdinal("comentario"))
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

    Public Function CargarReintegros(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Cargar_Reintegros)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "codtra", DbType.String, Rpt.CodTrabajador)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .numinterno = dr.GetString(dr.GetOrdinal("numInterno"))
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
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

    Public Function CargarMonedas() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Monedas)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarMonedas = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function CargarOtroConcepto(ByVal obj As ETEntregas) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CargarOtroConcepto)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "solicitud", DbType.String, obj.NumSolicitud)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarOtroConcepto = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function CargarTipoVehiculo() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CargarTipoVehiculo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarTipoVehiculo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function VerificaPlaca(ByVal placa As String, ByVal tfactura As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VerificaPlaca)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "PLACA", DbType.String, placa)
            db.AddInParameter(cmd, "TFACTURACION", DbType.String, tfactura)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            VerificaPlaca = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function VerificaUserUnico(ByVal usuario As String, ByVal cod_trabajador As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VerificaUserUnico)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, usuario)
            db.AddInParameter(cmd, "@COD_TRABAJADOR", DbType.String, cod_trabajador)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            VerificaUserUnico = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function LimiteTramites(ByVal cod_trabajador As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.LimiteTramites)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "@USUARIO", DbType.String, usuario)
            db.AddInParameter(cmd, "@CODTRABAJADOR", DbType.String, cod_trabajador)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            LimiteTramites = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function CargarTipoFacturacion() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CargarTipoFacturacion)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarTipoFacturacion = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function CargarAlquilerVehiculo() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CargarAlquilerVehiculo)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarAlquilerVehiculo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function CargarAlquilerVehiculoPlaca(ByVal Rpt As ETEntregas) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CargarAlquilerVehiculoPlaca)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "CODPROV", DbType.String, Rpt.codprov)
            db.AddInParameter(cmd, "PLACA", DbType.String, Rpt.placa)
            db.AddInParameter(cmd, "TFACTURACION", DbType.String, Rpt.tfacturacion)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CargarAlquilerVehiculoPlaca = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function

    Public Function ListarMonedas() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Monedas)
        Dim lResult As ETMyLista = Nothing
        Try

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codmoneda = dr.GetString(dr.GetOrdinal("cod_maestro2"))
                        .moneda = dr.GetString(dr.GetOrdinal("descrip"))
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

    Public Function ListarBancos() As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Bancos)
        Dim lResult As ETMyLista = Nothing
        Try
            'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codbanco = dr.GetString(dr.GetOrdinal("cod_maestro2"))
                        .banco = dr.GetString(dr.GetOrdinal("descrip"))
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

    Public Function ListarBeneficiarioDni(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_BeneficiarioDni)

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


    Public Function ListarLineacredito() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Lineacredito)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("placod"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .lineacredito = dr.GetDecimal(dr.GetOrdinal("lineacredito"))
                        .permiso = dr.GetInt32(dr.GetOrdinal("PERMISO"))
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

    Public Function ListarSuspension() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarSuspension)
        Dim lResult As ETMyLista = Nothing
        Try
            'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .nroruc = dr.GetString(dr.GetOrdinal("NRORUC"))
                        .Razon = dr.GetString(dr.GetOrdinal("RAZON"))
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("FECHA_SUSPENSION"))
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

    Public Function ListarRetencionRH() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarRetencionRH)
        Dim lResult As ETMyLista = Nothing
        Try
            'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .nroruc = dr.GetString(dr.GetOrdinal("NRORUC"))
                        .Razon = dr.GetString(dr.GetOrdinal("RAZON"))
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Serie = dr.GetString(dr.GetOrdinal("SERIE"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("NUMERO"))
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

    Public Function MantenimientoLineacredito(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal Ls_EntregaDetalle As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoLineacredito)

                db.AddInParameter(cmd, "tipo", DbType.Int16, Rpt.TipoOperacion)
                db.AddInParameter(cmd, "cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "placod", DbType.String, Rpt.CodTrabajador)
                db.AddInParameter(cmd, "lineacredito", DbType.Double, Rpt.lineacredito)
                db.AddInParameter(cmd, "permiso", DbType.Int32, Rpt.permiso)
                db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function ValidaLineacredito(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Valida_Lineacredito)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "placod", DbType.String, Rpt.CodTrabajador)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("placod"))
                        .lineacredito = dr.GetDecimal(dr.GetOrdinal("lineacredito"))
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

    Public Function ValidaExcesocredito(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Valida_Excesocredito)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "placod", DbType.String, Rpt.CodTrabajador)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .lineacredito = dr.GetDecimal(dr.GetOrdinal("lineacredito"))
                        .tipocambio = dr.GetDecimal(dr.GetOrdinal("tipocambio"))
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

    Public Function Listar_LiquidacionesCerradas(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If
        'Dim dato_sunat As New sg_consulta_documento_nacional.metodos()
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_LiquidacionesCerradas)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "fechainicio", DbType.DateTime, Rpt.FechaInicio)
            db.AddInParameter(cmd, "fechafin", DbType.DateTime, Rpt.FechaTerminacion)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .Estado = dr.GetString(dr.GetOrdinal("estado"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("fechacrea"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Usuario = dr.GetString(dr.GetOrdinal("usuario"))
                        .moneda = dr.GetString(dr.GetOrdinal("moneda"))
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("fechaaprobacion"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("REFERENCIA"))
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

    Public Function RecepcionarSolicitud(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                'For Each Row In Ls_Entrega
                Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.RecepcionarSolicitud)
                'If Row.codConcepto.ToString.Trim <> "" Then
                db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                db.AddInParameter(xmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
                db.AddInParameter(xmd, "idEstado", DbType.Int32, Rpt.idEstado)
                db.AddInParameter(xmd, "fechacontable", DbType.DateTime, Rpt.fechacontable)
                db.AddInParameter(xmd, "FLGPROVISION", DbType.Int32, Rpt.flgprovision)
                db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(xmd, Trans)
                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)
                'End If
                'Next
                'End If

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

    Public Function CodigoDescripcion() As ETMyLista
        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CodigoConcepto)

        Try

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codConcepto = dr.GetString(dr.GetOrdinal("codconcepto"))
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

    Public Function MantenimientoDescripciones(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDescripciones)
                'db.AddInParameter(cmd, "tipo", DbType.Int16, Rpt.TipoOperacion)
                'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "codConcepto", DbType.String, Rpt.codConcepto)
                db.AddInParameter(cmd, "tipoConcepto", DbType.String, Rpt.tipoconcepto)
                db.AddInParameter(cmd, "descripcion", DbType.String, Rpt.Descripcion)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function Listar_DetalleLiquidacionCopia(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DetalleLiquidacionCopia)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            Dim saldo As Double
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .fechaComp = dr.GetDateTime(dr.GetOrdinal("fecha"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .Serie = dr.GetString(dr.GetOrdinal("serie"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .Razon = dr.GetString(dr.GetOrdinal("RazSoc"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Concepto"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .codmotivoDetalle = dr.GetString(dr.GetOrdinal("codmotivo"))
                        .motivoDetalle = dr.GetString(dr.GetOrdinal("Motivoviaje"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("montototal"))
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Cantera = dr.GetString(dr.GetOrdinal("cantera"))
                        .TipoOperacion = 2
                        .idComp = dr.GetInt32(dr.GetOrdinal("idComp"))
                        saldo = dr.GetDecimal(dr.GetOrdinal("saldo"))
                        If saldo > 0 Then
                            .montoDevolucion = dr.GetDecimal(dr.GetOrdinal("saldo"))
                            .montoReintegro = 0
                        Else
                            .montoDevolucion = 0
                            .montoReintegro = dr.GetDecimal(dr.GetOrdinal("saldo"))
                        End If
                        If dr.GetString(dr.GetOrdinal("moneda")) = "S" Then
                            .moneda = "S/."
                        ElseIf dr.GetString(dr.GetOrdinal("moneda")) = "D" Then
                            .moneda = "US$"
                        End If
                        .tipocambio = dr.GetDecimal(dr.GetOrdinal("cambio"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        .flgcompra = dr.GetInt32(dr.GetOrdinal("flgcompra"))

                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
                        .banco = dr.GetString(dr.GetOrdinal("banco"))
                        .NumDocdevo = dr.GetString(dr.GetOrdinal("nro_doc"))
                        .idReemplazo = dr.GetInt32(dr.GetOrdinal("idReemplazo"))
                        .motivoReemplazo = dr.GetString(dr.GetOrdinal("motivoReemplazo"))
                        .comentario = dr.GetString(dr.GetOrdinal("comentario"))
                        .dias = dr.GetInt32(dr.GetOrdinal("dias"))
                        .personas = dr.GetInt32(dr.GetOrdinal("personas"))
                        .flgreal = dr.GetInt32(dr.GetOrdinal("flgreal"))
                        .nfila = dr.GetInt32(dr.GetOrdinal("nfila"))
                        .flgretencion = dr.GetInt32(dr.GetOrdinal("flgretencion"))
                        .IDANEXO3 = dr.GetInt32(dr.GetOrdinal("IDAUXI3"))
                        .ANEXO3 = dr.GetString(dr.GetOrdinal("AUXI3"))
                        .PLACA_TERCERO = dr.GetString(dr.GetOrdinal("PLACA_TERCERO"))
                        .codTipoDoc = dr.GetString(dr.GetOrdinal("codtipodoc"))
                        .igv = dr.GetDecimal(dr.GetOrdinal("igv"))
                        .igv_ori = dr.GetDecimal(dr.GetOrdinal("igv_ori"))
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

    Public Function MantenimientoLiquidacionCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoLiquidacionCopia)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "idComp", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "fecha", DbType.DateTime, Row.fechaComp)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "razon", DbType.String, Row.Razon)
                    db.AddInParameter(xmd, "codAuxiliar", DbType.String, Row.codAuxiliar)
                    db.AddInParameter(xmd, "codmotivoviaje", DbType.String, Row.codmotivoDetalle)
                    db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                    db.AddInParameter(xmd, "montototal", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "estado", DbType.Int32, Row.idEstado)
                    db.AddInParameter(xmd, "moneda", DbType.String, Row.moneda)
                    db.AddInParameter(xmd, "cambio", DbType.Double, Row.tipocambio)
                    db.AddInParameter(xmd, "montodoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "codarea", DbType.String, Row.codArea)
                    db.AddInParameter(xmd, "codCanteradet", DbType.String, Row.codCanteradet)
                    db.AddInParameter(xmd, "idReemplazo", DbType.Int32, Row.idReemplazo)
                    db.AddInParameter(xmd, "motivoReemplazo", DbType.String, Row.motivoReemplazo)
                    db.AddInParameter(xmd, "comentario", DbType.String, Row.comentario)
                    db.AddInParameter(xmd, "codCantera", DbType.String, Row.codCantera)
                    db.AddInParameter(xmd, "fechasalida", DbType.DateTime, Row.fechaSalida)
                    db.AddInParameter(xmd, "fecharetorno", DbType.DateTime, Row.fechaRetorno)
                    db.AddInParameter(xmd, "region", DbType.String, Row.Region)
                    db.AddInParameter(xmd, "motivo", DbType.String, Row.Motivo)
                    db.AddInParameter(xmd, "dias", DbType.Int32, Row.dias)
                    db.AddInParameter(xmd, "personas", DbType.Int32, Row.personas)
                    db.AddInParameter(xmd, "flgreal", DbType.Int32, Row.flgreal)
                    db.AddInParameter(xmd, "nfila", DbType.Int32, Row.nfila)
                    db.AddInParameter(xmd, "USUARIO", DbType.String, Row.Usuario)
                    db.AddInParameter(xmd, "FLGREVISADO", DbType.Int32, Row.flgpermiso)
                    db.AddInParameter(xmd, "IDANEXO3", DbType.Int32, Row.IDANEXO3)
                    db.AddInParameter(xmd, "ANEXO3", DbType.String, Row.ANEXO3)
                    db.AddInParameter(xmd, "PLACA_TERCERO", DbType.String, Row.PLACA_TERCERO)
                    db.AddInParameter(xmd, "igv", DbType.String, Row.igv)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function ListarAreasCuenta(ByVal Rpt As ETEntregas) As ETMyLista


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_AreasCuenta)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "codConcepto", DbType.String, Rpt.codConcepto)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codArea = dr.GetString(dr.GetOrdinal("cod_maestro2")).ToString.Trim
                        .Area = dr.GetString(dr.GetOrdinal("descrip")).ToString.Trim
                        .codCuenta = dr.GetString(dr.GetOrdinal("codCuenta")).ToString.Trim
                        .Cuenta = dr.GetString(dr.GetOrdinal("Cuenta")).ToString.Trim
                        .codCuentaBoleta = dr.GetString(dr.GetOrdinal("codCuentaBoleta")).ToString.Trim
                        .CuentaBoleta = dr.GetString(dr.GetOrdinal("CuentaBoleta")).ToString.Trim
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

    Public Function ListarCuentaContable() As ETMyLista

        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_CuentaContable)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codCuenta = dr.GetString(dr.GetOrdinal("cgcod"))
                        .Cuenta = dr.GetString(dr.GetOrdinal("cgdes"))
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

    Public Function MantenimientoSeteContable(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                For Each Row In Ls_Entrega

                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoSeteoContable)
                    If Row.codConcepto.ToString.Trim <> "" Then
                        db.AddInParameter(xmd, "codarea", DbType.String, Row.codArea)
                        db.AddInParameter(xmd, "codconcepto", DbType.String, Row.codConcepto)
                        db.AddInParameter(xmd, "cuenta", DbType.String, Row.codCuenta)
                        db.AddInParameter(xmd, "cuentaBoleta", DbType.String, Row.codCuentaBoleta)
                        db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                        db.ExecuteNonQuery(xmd, Trans)

                        lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                        If lResult.Respuesta <> 0 Then Err.Raise(10)
                    End If
                Next

                If lResult.Respuesta <> 0 Then Err.Raise(10)

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


    Public Function ListarAreasxUsuario(ByVal Rpt As ETEntregas) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_AreasUsuario)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.userlogin)
            db.AddInParameter(cmd, "tipo", DbType.String, Rpt.tipoAprobacion)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codArea = dr.GetString(dr.GetOrdinal("cod_maestro2"))
                        .Area = dr.GetString(dr.GetOrdinal("descrip"))
                        If dr.GetString(dr.GetOrdinal("USUARIO")).ToString.Trim = "" Then
                            .Action = False
                        Else
                            .Action = True
                        End If

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



    Public Function ListarTrabajadoresArea() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_TrabajadoresArea)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("placod"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        '.Descripcion = dr.GetString(dr.GetOrdinal("esjefe"))
                        .CodJefe = dr.GetString(dr.GetOrdinal("codigoJefe"))
                        .NomJefe = dr.GetString(dr.GetOrdinal("nomJefe"))
                        .Cargo = dr.GetString(dr.GetOrdinal("CARGO"))
                        .Areabd = dr.GetString(dr.GetOrdinal("areabd"))
                        .telefono = dr.GetString(dr.GetOrdinal("telefono"))
                        .Email = dr.GetString(dr.GetOrdinal("correo"))
                        .dni = dr.GetString(dr.GetOrdinal("dni"))
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

    Public Function MantenimientoTrabajadorArea(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoTrabajadorArea)

                db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
                db.AddInParameter(cmd, "codtrabajador", DbType.String, Rpt.CodTrabajador)
                db.AddInParameter(cmd, "flgjefe", DbType.Int32, Rpt.flgjefe)
                db.AddInParameter(cmd, "codjefe", DbType.String, Rpt.CodJefe)
                db.AddInParameter(cmd, "dni", DbType.String, Rpt.dni)
                db.AddInParameter(cmd, "telefono", DbType.String, Rpt.telefono)
                db.AddInParameter(cmd, "email", DbType.String, Rpt.Email)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function ListarAreaTrabajador(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_AreaTrabajador)

        Try
            'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "codtrabajador", DbType.String, Rpt.CodTrabajador)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
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

    Public Function RecepcionarSolicitudPend(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.RecepcionarSolicitudPend)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
                    db.AddInParameter(xmd, "idEstado", DbType.Int32, Row.idEstado)
                    db.AddInParameter(xmd, "fechacontable", DbType.DateTime, Rpt.fechacontable)
                    db.AddInParameter(xmd, "idPendiente", DbType.Int32, Rpt.ID)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function MantenimientoLiquidacionCopiaPend(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoLiquidacionCopiaPend)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "idComp", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "fecha", DbType.DateTime, Row.fechaComp)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "razon", DbType.String, Row.Razon)
                    db.AddInParameter(xmd, "codAuxiliar", DbType.String, Row.codAuxiliar)
                    db.AddInParameter(xmd, "codmotivoviaje", DbType.String, Row.codmotivoDetalle)
                    db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                    db.AddInParameter(xmd, "montototal", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "estado", DbType.Int32, Row.idEstado)
                    db.AddInParameter(xmd, "moneda", DbType.String, Row.moneda)
                    db.AddInParameter(xmd, "cambio", DbType.Double, Row.tipocambio)
                    db.AddInParameter(xmd, "montodoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "codarea", DbType.String, Row.codArea)
                    db.AddInParameter(xmd, "codCanteradet", DbType.String, Row.codCanteradet)
                    db.AddInParameter(xmd, "idReemplazo", DbType.Int32, Row.idReemplazo)
                    db.AddInParameter(xmd, "motivoReemplazo", DbType.String, Row.motivoReemplazo)
                    db.AddInParameter(xmd, "comentario", DbType.String, Row.comentario)
                    db.AddInParameter(xmd, "idPendiente", DbType.Int32, Row.ID)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function Listar_DetalleLiquidacionPendCopia(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DetalleLiquidacionPendCopia)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "idPendiente", DbType.String, Rpt.ID)
            Dim saldo As Double
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .fechaComp = dr.GetDateTime(dr.GetOrdinal("fecha"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .Serie = dr.GetString(dr.GetOrdinal("serie"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .Razon = dr.GetString(dr.GetOrdinal("RazSoc"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Concepto"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .codmotivoDetalle = dr.GetString(dr.GetOrdinal("codmotivo"))
                        .motivoDetalle = dr.GetString(dr.GetOrdinal("Motivoviaje"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("montototal"))
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Cantera = dr.GetString(dr.GetOrdinal("cantera"))
                        .TipoOperacion = 2
                        .idComp = dr.GetInt32(dr.GetOrdinal("idComp"))
                        saldo = dr.GetDecimal(dr.GetOrdinal("saldo"))
                        If saldo > 0 Then
                            .montoDevolucion = dr.GetDecimal(dr.GetOrdinal("saldo"))
                            .montoReintegro = 0
                        Else
                            .montoDevolucion = 0
                            .montoReintegro = dr.GetDecimal(dr.GetOrdinal("saldo"))
                        End If
                        If dr.GetString(dr.GetOrdinal("moneda")) = "S" Then
                            .moneda = "S/."
                        ElseIf dr.GetString(dr.GetOrdinal("moneda")) = "D" Then
                            .moneda = "US$"
                        End If
                        .tipocambio = dr.GetDecimal(dr.GetOrdinal("cambio"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        .flgcompra = dr.GetInt32(dr.GetOrdinal("flgcompra"))

                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
                        .banco = dr.GetString(dr.GetOrdinal("banco"))
                        .NumDocdevo = dr.GetString(dr.GetOrdinal("nro_doc"))
                        .idReemplazo = dr.GetInt32(dr.GetOrdinal("idReemplazo"))
                        .motivoReemplazo = dr.GetString(dr.GetOrdinal("motivoReemplazo"))
                        .comentario = dr.GetString(dr.GetOrdinal("comentario"))

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

    Public Function MantenimientoDocInterno(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDocAsociado)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "id", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                    db.AddInParameter(xmd, "importe", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "importedoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "coduxiliar", DbType.String, Row.codAuxiliar)
                    db.AddInParameter(xmd, "comentario", DbType.String, Row.comentario)
                    db.AddInParameter(xmd, "dias", DbType.Int32, Row.dias)
                    db.AddInParameter(xmd, "personas", DbType.Int32, Row.personas)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function Listar_DocAsociadoLiqui(ByVal Rpt As ETEntregas) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DocAsociadoLiqui)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .item = cont
                        .idComp = dr.GetInt32(dr.GetOrdinal("id"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("concepto"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("importe"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("importedoc"))
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .comentario = dr.GetString(dr.GetOrdinal("comentario"))
                        .dias = dr.GetInt32(dr.GetOrdinal("dias"))
                        .personas = dr.GetInt32(dr.GetOrdinal("personas"))
                        .TipoOperacion = 2
                        cont += 1
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

    Public Function MantenimientoDocInternoPend(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDocAsociadoPend)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "id", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                    db.AddInParameter(xmd, "importe", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "importedoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "coduxiliar", DbType.String, Row.codAuxiliar)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function Listar_DocAsociadoLiquiPend(ByVal Rpt As ETEntregas) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DocAsociadoLiquiPend)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .item = cont
                        .idComp = dr.GetInt32(dr.GetOrdinal("id"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("concepto"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("importe"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("importedoc"))
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .TipoOperacion = 2
                        cont += 1
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

    Public Function Listar_DocAsociadoLiquiCopia(ByVal Rpt As ETEntregas) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DocAsociadoLiquiCopia)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .item = cont
                        .idComp = dr.GetInt32(dr.GetOrdinal("id"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("concepto"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("importe"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("importedoc"))
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .comentario = dr.GetString(dr.GetOrdinal("comentario"))
                        .dias = dr.GetInt32(dr.GetOrdinal("dias"))
                        .personas = dr.GetInt32(dr.GetOrdinal("personas"))
                        .TipoOperacion = 2
                        cont += 1
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

    Public Function Listar_DocAsociadoLiquiPendCopia(ByVal Rpt As ETEntregas) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DocAsociadoLiquiPendCopia)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "idPendiente", DbType.String, Rpt.ID)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .item = cont
                        .idComp = dr.GetInt32(dr.GetOrdinal("id"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("concepto"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("importe"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("importedoc"))
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliar"))
                        .TipoOperacion = 2
                        cont += 1
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

    Public Function MantenimientoDocInternoCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDocAsociadoCopia)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "id", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                    db.AddInParameter(xmd, "importe", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "importedoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "coduxiliar", DbType.String, Row.codAuxiliar)
                    db.AddInParameter(xmd, "comentario", DbType.String, Row.comentario)
                    db.AddInParameter(xmd, "dias", DbType.Int32, Row.dias)
                    db.AddInParameter(xmd, "personas", DbType.Int32, Row.personas)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function MantenimientoDocInternoPendCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDocAsociadoPendCopia)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "id", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "codConcepto", DbType.String, Row.codConcepto)
                    db.AddInParameter(xmd, "importe", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "importedoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "coduxiliar", DbType.String, Row.codAuxiliar)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function FlagAuxiliar(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.FlagAuxiliar)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "codArea", DbType.String, Rpt.codArea)
            db.AddInParameter(cmd, "codConcepto", DbType.String, Rpt.codConcepto)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .auxi = dr.GetString(dr.GetOrdinal("auxi"))
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

    Public Function ListarAuxiliar(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Auxiliar)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "auxi", DbType.String, Rpt.auxi)
            db.AddInParameter(cmd, "tipprod", DbType.String, Rpt.tipprod)
            db.AddInParameter(cmd, "codconcepto", DbType.String, Rpt.codConcepto)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("codigo"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("descripcion"))
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

    Public Function ListarAuxiliar3(ByVal Rpt As ETEntregas) As ETMyLista

        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarAuxiliar3)

        Try
            db.AddInParameter(cmd, "@TIPO", DbType.String, Rpt.Tipo)
            db.AddInParameter(cmd, "@CCOSTO", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codAuxiliar = dr.GetString(dr.GetOrdinal("CODIGO"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("DESCRIPCION"))
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

    Public Function MantenimientoDocMovilidad(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tipotabla As Int32) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDocMovilidad)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "id", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "fecha", DbType.DateTime, Row.Fecha)
                    db.AddInParameter(xmd, "motivo", DbType.String, Row.Motivo)
                    db.AddInParameter(xmd, "destino", DbType.String, Row.Destino)
                    db.AddInParameter(xmd, "direccion", DbType.String, Row.Direccion)
                    db.AddInParameter(xmd, "importe", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "importedoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "tipotabla", DbType.String, tipotabla)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function MantenimientoDetalleRecibo(ByVal numsolicitud As String, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        'If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
        '    Return lResult
        'End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDetalleRecibo)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "@NUMSOLICITUD", DbType.String, numsolicitud)
                    db.AddInParameter(xmd, "@NFILA", DbType.Int32, Row.fila)
                    db.AddInParameter(xmd, "@TIPO", DbType.String, Row.TipoRecibo)
                    db.AddInParameter(xmd, "@IDCONCEPTO", DbType.Int32, Row.ID)
                    db.AddInParameter(xmd, "@DESCRIPCION", DbType.String, Row.Descripcion)
                    db.AddInParameter(xmd, "@MONTO", DbType.Double, Row.montoTotal)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function MantenimientoDetalleReciboCopia(ByVal numsolicitud As String, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        'If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
        '    Return lResult
        'End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDetalleReciboCopia)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "@NUMSOLICITUD", DbType.String, numsolicitud)
                    db.AddInParameter(xmd, "@NFILA", DbType.Int32, Row.fila)
                    db.AddInParameter(xmd, "@TIPO", DbType.String, Row.TipoRecibo)
                    db.AddInParameter(xmd, "@IDCONCEPTO", DbType.Int32, Row.ID)
                    db.AddInParameter(xmd, "@DESCRIPCION", DbType.String, Row.Descripcion)
                    db.AddInParameter(xmd, "@MONTO", DbType.Double, Row.montoTotal)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function Listar_DocMovilidad(ByVal Rpt As ETEntregas, ByVal tipotabla As Int32) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DoMovilidad)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "tipotabla", DbType.String, tipotabla)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .item = cont
                        .idComp = dr.GetInt32(dr.GetOrdinal("id"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("fecha"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .Destino = dr.GetString(dr.GetOrdinal("destino"))
                        .Direccion = dr.GetString(dr.GetOrdinal("direccion"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("importe"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("importedoc"))
                        .TipoOperacion = 2
                        cont += 1
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

    Public Function Listar_DocMovilidadCopia(ByVal Rpt As ETEntregas, ByVal tipotabla As Int32) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DoMovilidadCopia)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "tipotabla", DbType.String, tipotabla)
            db.AddInParameter(cmd, "idPendiente", DbType.Int32, Rpt.ID)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .item = cont
                        .idComp = dr.GetInt32(dr.GetOrdinal("id"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("fecha"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .Destino = dr.GetString(dr.GetOrdinal("destino"))
                        .Direccion = dr.GetString(dr.GetOrdinal("direccion"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("importe"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("importedoc"))
                        .TipoOperacion = 2
                        cont += 1
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

    Public Function MantenimientoDocMovilidadCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tipotabla As Int32) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDocMovilidadCopia)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "id", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "fecha", DbType.DateTime, Row.Fecha)
                    db.AddInParameter(xmd, "motivo", DbType.String, Row.Motivo)
                    db.AddInParameter(xmd, "destino", DbType.String, Row.Destino)
                    db.AddInParameter(xmd, "direccion", DbType.String, Row.Direccion)
                    db.AddInParameter(xmd, "importe", DbType.Double, Row.montoTotalParcial)
                    db.AddInParameter(xmd, "importedoc", DbType.Double, Row.montoTotal)
                    db.AddInParameter(xmd, "tipotabla", DbType.String, tipotabla)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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
    Public Function ListarCentroCostoPlaca(ByVal periodo As String) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_CentroCostoPlaca)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "año", DbType.String, periodo)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            ListarCentroCostoPlaca = Ds

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarCentroCosto() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_CentroCosto)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codArea = dr.GetString(dr.GetOrdinal("codcencos"))
                        .Area = dr.GetString(dr.GetOrdinal("descripcion"))
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

    Public Function SolicitudxNumeroLiquidacion(ByVal Rpt As ETEntregas) As ETMyLista
        'B  yVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_SolicitudxNumeroLiquidacion)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "espendiente", DbType.String, Rpt.espendiente)
            db.AddInParameter(cmd, "idPendiente", DbType.String, Rpt.ID)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodTrabajador = dr.GetString(dr.GetOrdinal("codtrabajador"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Area = dr.GetString(dr.GetOrdinal("area"))
                        .JefeArea = dr.GetString(dr.GetOrdinal("jefeArea"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .fechaSalida = dr.GetDateTime(dr.GetOrdinal("fecsalida"))
                        .fechaRetorno = dr.GetDateTime(dr.GetOrdinal("fecretorno"))
                        .codCantera = dr.GetString(dr.GetOrdinal("codcantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("cantera"))
                        .Region = dr.GetString(dr.GetOrdinal("region"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .codConcepto = dr.GetString(dr.GetOrdinal("codConcepto"))
                        .montoParcial = dr.GetDecimal(dr.GetOrdinal("monto"))
                        .totaldias = dr.GetInt32(dr.GetOrdinal("dias"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("montototal"))
                        .idEstado = dr.GetInt32(dr.GetOrdinal("estado"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
                        .banco = dr.GetString(dr.GetOrdinal("banco"))
                        .nrocta = dr.GetString(dr.GetOrdinal("nro_cta"))
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
                        .fechacontable = dr.GetDateTime(dr.GetOrdinal("fechacontable"))
                        .nVoucher = dr.GetString(dr.GetOrdinal("numasiento"))
                        .flgprovision = dr.GetInt32(dr.GetOrdinal("flgprovision"))
                        .flgpermiso = dr.GetInt32(dr.GetOrdinal("REVISION"))
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

    Public Function VerificaCierreContable(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VerificaCierreContable)

        Try
            db.AddInParameter(cmd, "año", DbType.Int32, Rpt.añocontable)
            db.AddInParameter(cmd, "mes", DbType.Int32, Rpt.mescontable)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .estadocontable = dr.GetInt32(dr.GetOrdinal("ESTADO_MES"))
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

    Public Function VerificaDevolucion(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VerificaDevolucion)

        Try
            db.AddInParameter(cmd, "idliquidacion", DbType.String, Rpt.idComp)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .tipodeposito = dr.GetString(dr.GetOrdinal("tipodeposito"))
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

    Public Function verificarDocumentos(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.verficaDocumentos)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "tipodoc", DbType.String, Rpt.TipoDoc)
            db.AddInParameter(cmd, "ruc", DbType.String, Rpt.nroruc)
            db.AddInParameter(cmd, "numdoc", DbType.String, Rpt.NumDoc)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .nroruc = dr.GetString(dr.GetOrdinal("ruc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipo_doc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("num_doc"))

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

    Public Function GeneraAsientoEntregas(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.GeneraAsientoEntregas)

                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "NUMMASIENTO", DbType.String, Rpt.nVoucher)
                db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
                db.AddInParameter(cmd, "FECHACONTABLE", DbType.DateTime, Rpt.fechacontable)
                db.AddInParameter(cmd, "MESCONTABLE", DbType.String, Rpt.mescontable)
                db.AddInParameter(cmd, "AÑOCONTABLE", DbType.String, Rpt.añocontable)
                db.AddInParameter(cmd, "USERCREA", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "RESPUESTA", DbType.Int16, 10)
                db.AddOutParameter(cmd, "VOUCHER", DbType.String, 10)
                db.AddOutParameter(cmd, "VOUCHERINTERNO", DbType.String, 10)
                db.ExecuteNonQuery(cmd, Trans)
                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "RESPUESTA"))
                lResult.nVoucher = Convert.ToString(db.GetParameterValue(cmd, "VOUCHER"))
                lResult.nVoucherInerno = Convert.ToString(db.GetParameterValue(cmd, "VOUCHERINTERNO"))
                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function GeneraAsientoEntregasProvision(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.GeneraAsientoEntregasProvision)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "FECHACONTABLE", DbType.DateTime, Rpt.fechacontable)
                db.AddInParameter(cmd, "USERCREA", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "RESPUESTA", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "RESPUESTA"))
                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function GeneraAsientoEntregasPend(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.GeneraAsientoEntregasPend)

                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "NUMMASIENTO", DbType.String, Rpt.nVoucher)
                db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
                db.AddInParameter(cmd, "FECHACONTABLE", DbType.DateTime, Rpt.fechacontable)
                db.AddInParameter(cmd, "MESCONTABLE", DbType.String, Rpt.mescontable)
                db.AddInParameter(cmd, "AÑOCONTABLE", DbType.String, Rpt.añocontable)
                db.AddInParameter(cmd, "USERCREA", DbType.String, Rpt.Usuario)
                db.AddInParameter(cmd, "IDPENDIENTE", DbType.Int32, Rpt.ID)
                db.AddOutParameter(cmd, "RESPUESTA", DbType.Int16, 10)
                db.AddOutParameter(cmd, "VOUCHER", DbType.String, 10)
                db.AddOutParameter(cmd, "VOUCHERINTERNO", DbType.String, 10)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "RESPUESTA"))
                lResult.nVoucher = Convert.ToString(db.GetParameterValue(cmd, "VOUCHER"))
                lResult.nVoucherInerno = Convert.ToString(db.GetParameterValue(cmd, "VOUCHERINTERNO"))
                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function verificaReintegro(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.verificaReintegro)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .ID = dr.GetInt32(dr.GetOrdinal("id"))
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

    Public Function ActualizaRegion(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Acualiza_Cantera)

                db.AddInParameter(cmd, "codcantera", DbType.String, Rpt.codCantera)
                db.AddInParameter(cmd, "region", DbType.String, Rpt.Region)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function ConsultaReporte(ByVal Rpt As ETEntregas) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CONSULTA_ENTREGAS)
        cmd.CommandTimeout = 60000
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "TIPO", DbType.Int32, Rpt.Tipo)
            db.AddInParameter(cmd, "CODTRABAJADOR", DbType.String, Rpt.CodTrabajador)
            db.AddInParameter(cmd, "FECHAINI", DbType.Date, Rpt.FechaInicio)
            db.AddInParameter(cmd, "FECHAFIN", DbType.Date, Rpt.FechaTerminacion)
            db.AddInParameter(cmd, "TIPOFILTRO", DbType.String, Rpt.tipofiltro)
            db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "TIPOIMPRESION", DbType.Int32, Rpt.TipoImpresion)
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultaReporte = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try


        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CONSULTA_ENTREGAS)

        'Try
        '    db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
        '    db.AddInParameter(cmd, "TIPO", DbType.Int32, Rpt.Tipo)
        '    db.AddInParameter(cmd, "CODTRABAJADOR", DbType.String, Rpt.CodTrabajador)
        '    db.AddInParameter(cmd, "FECHAINI", DbType.Date, Rpt.FechaInicio)
        '    db.AddInParameter(cmd, "FECHAFIN", DbType.Date, Rpt.FechaTerminacion)
        '    db.AddInParameter(cmd, "TIPOFILTRO", DbType.String, Rpt.tipofiltro)
        '    db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
        '    db.AddInParameter(cmd, "TIPOIMPRESION", DbType.Int32, Rpt.TipoImpresion)
        '    db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
        '    lResult = New ETMyLista
        '    Using dr As IDataReader = db.ExecuteReader(cmd)
        '        While dr.Read
        '            Entidad.Entregas = New ETEntregas
        '            With Entidad.Entregas
        '                .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
        '                .Fecha = dr.GetDateTime(dr.GetOrdinal("FECHAEMISION"))
        '                .montoParcial = dr.GetDecimal(dr.GetOrdinal("MONTOSOLICITUD"))
        '                .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("MONTOLIQUIDACION"))
        '                .Motivo = dr.GetString(dr.GetOrdinal("MOTIVO"))
        '                .montoTotal = dr.GetDecimal(dr.GetOrdinal("SALDO"))
        '                .moneda = dr.GetString(dr.GetOrdinal("MONEDA"))
        '            End With
        '            lResult.Ls_Entrega.Add(Entidad.Entregas)
        '        End While
        '        If dr IsNot Nothing Then dr.Close()
        '        lResult.Validacion = Boolean.TrueString
        '    End Using

        'Catch Err As Exception

        '    MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        '    lResult = Nothing

        'End Try

        'Return lResult

    End Function
    Public Function ListarGatosVehiculos(ByVal periodo As String, ByVal cencos As String, ByVal placa As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarGatosVehiculos)
                db.AddInParameter(cmd, "@año", DbType.String, periodo)
                db.AddInParameter(cmd, "@ccosto", DbType.String, cencos)
                db.AddInParameter(cmd, "@placa", DbType.String, placa)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function
    Public Function ListarPlacasxCentro(ByVal periodo As String, ByVal cgcod As String, ByVal placa As String) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim dt As DataSet
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarPlacasxCentro)
                db.AddInParameter(cmd, "@año", DbType.String, periodo)
                db.AddInParameter(cmd, "@ccosto", DbType.String, cgcod)
                db.AddInParameter(cmd, "@placa", DbType.String, placa)
                dt = db.ExecuteDataSet(cmd)
                Trans.Commit()
                Conexion.Close()
                Return dt
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try
        End Using
    End Function

    Public Function CorreoSaldo(ByVal codtrabajador As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CORREO_SALDO_ENTREGAS)
        cmd.CommandTimeout = 60000
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "@COD_TRABAJADOR", DbType.String, codtrabajador)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            CorreoSaldo = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarCombustible() As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Combustible)

        Try
            'db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        '.Galones = dr.GetDecimal(dr.GetOrdinal("Galones"))
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

    Public Function MantenimientoDocCombustible(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tipotabla As Int32) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDocCombustible)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "id", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "descripcion", DbType.String, Row.Descripcion)
                    db.AddInParameter(xmd, "galones", DbType.Double, Row.Galones)
                    db.AddInParameter(xmd, "importe", DbType.Double, Row.montoTotalParcial)
                    '<JOSF 23112022>
                    db.AddInParameter(xmd, "kilometraje", DbType.Double, Row.Kilometraje)
                    '</JOSF 23112022>
                    db.AddInParameter(xmd, "tipotabla", DbType.String, tipotabla)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function Listar_DocCombustible(ByVal Rpt As ETEntregas, ByVal tipotabla As Int32) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DocCombustible)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "tipotabla", DbType.String, tipotabla)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .item = cont
                        .idComp = dr.GetInt32(dr.GetOrdinal("id"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        .Galones = dr.GetDecimal(dr.GetOrdinal("galones"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("importe"))
                        .TipoOperacion = 2
                        cont += 1
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


    Public Function Listar_DocDetalleRH(ByVal Rpt As ETEntregas) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DocDetalleRH)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            lResult = New ETMyLista
            Dim idliqui As Int32 = 0
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        If idliqui <> dr.GetInt32(dr.GetOrdinal("IDLIQUIDACIONDET")) Then cont = 0
                        .item = cont
                        idliqui = dr.GetInt32(dr.GetOrdinal("IDLIQUIDACIONDET"))
                        .idComp = dr.GetInt32(dr.GetOrdinal("IDLIQUIDACIONDET"))
                        .fila = dr.GetInt32(dr.GetOrdinal("NFILA"))
                        .TipoRecibo = dr.GetString(dr.GetOrdinal("TIPO"))
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Concepto = dr.GetString(dr.GetOrdinal("CONCEPTO"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("DESCRIPCION"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("MONTO"))
                        cont += 1
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

    Public Function Listar_DocDetalleRHCopia(ByVal Rpt As ETEntregas) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DocDetalleRHCopia)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            lResult = New ETMyLista
            Dim idliqui As Int32 = 0
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        If idliqui <> dr.GetInt32(dr.GetOrdinal("IDLIQUIDACIONDET")) Then cont = 0
                        .item = cont
                        idliqui = dr.GetInt32(dr.GetOrdinal("IDLIQUIDACIONDET"))
                        .idComp = dr.GetInt32(dr.GetOrdinal("IDLIQUIDACIONDET"))
                        .fila = dr.GetInt32(dr.GetOrdinal("NFILA"))
                        .TipoRecibo = dr.GetString(dr.GetOrdinal("TIPO"))
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Concepto = dr.GetString(dr.GetOrdinal("CONCEPTO"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("DESCRIPCION"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("MONTO"))
                        cont += 1
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

    Public Function Listar_DocCombustibleCopia(ByVal Rpt As ETEntregas, ByVal tipotabla As Int32) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_DoCombustibleCopia)
        Dim cont As Int32 = 0
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "tipotabla", DbType.String, tipotabla)
            db.AddInParameter(cmd, "idPendiente", DbType.Int32, Rpt.ID)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .item = cont
                        .idComp = dr.GetInt32(dr.GetOrdinal("id"))
                        .nroruc = dr.GetString(dr.GetOrdinal("nroruc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("descripcion"))
                        .Galones = dr.GetDecimal(dr.GetOrdinal("galones"))
                        .montoTotalParcial = dr.GetDecimal(dr.GetOrdinal("importe"))
                        .TipoOperacion = 2
                        cont += 1
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

    Public Function MantenimientoDocCombustibleCopia(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas), ByVal tipotabla As Int32) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing OrElse Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoDocCombustibleCopia)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "tipo", DbType.Int16, Row.TipoOperacion)
                    db.AddInParameter(xmd, "id", DbType.Int32, Row.idComp)
                    db.AddInParameter(xmd, "numsolicitud", DbType.String, Row.NumSolicitud)
                    db.AddInParameter(xmd, "tipodoc", DbType.String, Row.TipoDoc)
                    db.AddInParameter(xmd, "numdoc", DbType.String, Row.NumDoc)
                    db.AddInParameter(xmd, "nroruc", DbType.String, Row.nroruc)
                    db.AddInParameter(xmd, "descripcion", DbType.String, Row.Descripcion)
                    db.AddInParameter(xmd, "galones", DbType.Double, Row.Galones)
                    db.AddInParameter(xmd, "importe", DbType.Double, Row.montoTotalParcial)
                    '<JOSF 29/12/2022>
                    db.AddInParameter(xmd, "kilometraje", DbType.Double, Row.montoTotalParcial)
                    '</JOSF 29/12/2022>
                    db.AddInParameter(xmd, "tipotabla", DbType.String, tipotabla)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function ConsultaCombustible(ByVal Rpt As ETEntregas) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ConsultaCombustible)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "codtrabajador", DbType.String, Rpt.CodTrabajador)
            db.AddInParameter(cmd, "fecha1", DbType.Date, Rpt.FechaInicio)
            db.AddInParameter(cmd, "fecha2", DbType.Date, Rpt.FechaTerminacion)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("fecha"))
                        .TipoDoc = dr.GetString(dr.GetOrdinal("tipodoc"))
                        .NumDoc = dr.GetString(dr.GetOrdinal("numdoc"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Cantera = dr.GetString(dr.GetOrdinal("canteras"))
                        .Auxiliar = dr.GetString(dr.GetOrdinal("auxiliares"))
                        .Combustible = dr.GetString(dr.GetOrdinal("combustible"))
                        .Galones = dr.GetDecimal(dr.GetOrdinal("galones"))
                        .Proveedor = dr.GetString(dr.GetOrdinal("proveedor"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .montoParcial = dr.GetDecimal(dr.GetOrdinal("costogalon"))
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .numinterno = dr.GetString(dr.GetOrdinal("NUMASIENTO"))
                        '<JOSF 28/12/2022>
                        '.Kilometraje = dr.GetDecimal(dr.GetOrdinal("kilometraje"))
                        '</JOSF 28/12/2022>
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

    Public Function ListarCombustibleMant() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_Combustible)
        Dim lResult As ETMyLista = Nothing
        Try


            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .ID = dr.GetInt32(dr.GetOrdinal("id"))
                        .Combustible = dr.GetString(dr.GetOrdinal("descripcion"))
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

    Public Function MantenimientoCombustible(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoCombustible)
                db.AddInParameter(cmd, "tipo", DbType.String, Rpt.TipoOperacion)
                db.AddInParameter(cmd, "id", DbType.String, Rpt.ID)
                db.AddInParameter(cmd, "descripcion", DbType.String, Rpt.Combustible)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

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

    Public Function ActualizaCombustible(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ACTUALIZA_COMBUSTIBLE)

                db.AddInParameter(cmd, "ID", DbType.String, Rpt.ID)
                db.AddInParameter(cmd, "DESCRIPCION", DbType.String, Rpt.Combustible)
                db.AddInParameter(cmd, "GALONES", DbType.Decimal, Rpt.Galones)
                db.ExecuteNonQuery(cmd, Trans)

                'lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

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

    Public Function ListarAreasIngreso(ByVal Rpt As ETEntregas) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_AreasIngreso)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.userlogin)
            db.AddInParameter(cmd, "tipo", DbType.String, Rpt.tipoAprobacion)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codArea = dr.GetString(dr.GetOrdinal("cod_maestro2"))
                        .Area = dr.GetString(dr.GetOrdinal("descrip"))
                        If dr.GetString(dr.GetOrdinal("USUARIO")).ToString.Trim = "" Then
                            .Action = False
                        Else
                            .Action = True
                        End If

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

    Public Function MantenimientoUsuarioIngreso(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                lResult = New ETEntregas
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoUsuarioIngreso)
                    db.AddInParameter(xmd, "usuario", DbType.String, Row.userlogin)
                    db.AddInParameter(xmd, "codarea", DbType.String, Row.codArea)
                    db.AddInParameter(xmd, "tipo", DbType.Int32, Row.tipoAprobacion)
                    db.AddInParameter(xmd, "check", DbType.Int32, Row.check)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))
                    If lResult.Respuesta <> 0 Then Err.Raise(10)
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

    Public Function ListarSeteoCorreo(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarSeteoCorreo)

        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "CODIGO", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .CodJefe = dr.GetString(dr.GetOrdinal("Placod"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("NombreTrabajador"))
                        .Usuario = dr.GetString(dr.GetOrdinal("Usuario"))
                        .Email = dr.GetString(dr.GetOrdinal("Email"))
                        If dr.GetString(dr.GetOrdinal("CodTrabajador")).ToString.Trim = "" Then
                            .Action = False
                        Else
                            .Action = True
                        End If
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

    Public Function MantenimientoSeteoCorreo(ByVal Rpt As ETEntregas, ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                lResult = New ETEntregas
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoSeteocorreo)
                    db.AddInParameter(xmd, "codtrabajador", DbType.String, Row.CodTrabajador)
                    db.AddInParameter(xmd, "codjefe", DbType.String, Row.CodJefe)
                    db.AddInParameter(xmd, "mail", DbType.String, Row.Email)
                    db.AddInParameter(xmd, "check", DbType.Int32, Row.check)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))
                    If lResult.Respuesta <> 0 Then Err.Raise(10)
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

    Public Function Listar_LiquidacionesRevision(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If
        'Dim dato_sunat As New sg_consulta_documento_nacional.metodos()
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_LiquidacionesRevision)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .Estado = dr.GetString(dr.GetOrdinal("estado"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("fechacrea"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Usuario = dr.GetString(dr.GetOrdinal("usuario"))
                        .moneda = dr.GetString(dr.GetOrdinal("moneda"))
                        .flgpermiso = dr.GetInt32(dr.GetOrdinal("flgpermiso"))
                        .ID = dr.GetInt32(dr.GetOrdinal("id"))
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

    Public Function LimiteGastos(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.LimiteGastos)

        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "numsolicitud", DbType.String, Rpt.NumSolicitud)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("fecha"))
                        .gastoAlimentacion = dr.GetDecimal(dr.GetOrdinal("alimentacion"))
                        .gastoHospedaje = dr.GetDecimal(dr.GetOrdinal("hospedaje"))
                        .gastoMovilidad = dr.GetDecimal(dr.GetOrdinal("movilidad"))
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
    Public Function ListarCanterasUEA(ByVal Rpt As ETEntregas) As ETMyLista
        'ByVal Rpt As ETEntregas

        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_CanterasUEA)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "UNIDAD", DbType.String, Rpt.codConcepto)
            'db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .codCantera = dr.GetString(dr.GetOrdinal("codcantera"))
                        .Cantera = dr.GetString(dr.GetOrdinal("descripcion"))
                        .Region = dr.GetString(dr.GetOrdinal("region"))
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

    Public Function MANTINGRESOMINERALSATAMIN(ByVal Ls_Entrega As List(Of ETEntregas)) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Ls_Entrega Is Nothing Then
            Return lResult
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                lResult = New ETEntregas
                'If Rpt.TipoOperacion <> 3 Then
                For Each Row In Ls_Entrega
                    Dim xmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MANTINGRESOMINERALSATAMIN)
                    'If Row.codConcepto.ToString.Trim <> "" Then
                    db.AddInParameter(xmd, "COD_PROD", DbType.String, Row.codMineral)
                    db.AddInParameter(xmd, "CANTERA", DbType.String, Row.Cantera)
                    db.AddInParameter(xmd, "MINERAL", DbType.String, Row.Mineral)
                    db.AddInParameter(xmd, "ACUMULADO", DbType.Decimal, Row.acumulado)
                    db.AddInParameter(xmd, "UEA", DbType.String, Row.UEA)
                    db.AddInParameter(xmd, "COD_UEA", DbType.String, Row.codUEA)
                    db.AddInParameter(xmd, "TIPO", DbType.String, Row.tipoIngreso)
                    db.AddInParameter(xmd, "MES", DbType.Int32, Row.Mes)
                    db.AddInParameter(xmd, "AÑO", DbType.Int32, Row.Anho)
                    db.AddInParameter(xmd, "USERCREA", DbType.String, Row.Usuario)
                    db.AddOutParameter(xmd, "RESPUESTA", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "RESPUESTA"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
                    'End If
                Next
                'End If

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

    Public Function validarReciboHonorario(ByVal Rpt As ETEntregas) As String
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return ""
        End If


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VALIDARECIBOHONORARIO)

        Try
            lResult = New ETMyLista
            db.AddInParameter(cmd, "AÑO", DbType.Int32, Rpt.año)
            db.AddInParameter(cmd, "MES", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "RUC", DbType.String, Rpt.nroruc)
            db.AddInParameter(cmd, "NUMDOC", DbType.String, Rpt.NumDoc)
            db.AddInParameter(cmd, "MONTO", DbType.Double, Rpt.montoTotal)
            db.AddInParameter(cmd, "MONTO_COMPROB", DbType.Double, Rpt.montoParcial)
            db.AddInParameter(cmd, "MONTO_COMPROB_DIA", DbType.Double, Rpt.montoTotalParcial)
            db.AddInParameter(cmd, "FECHA", DbType.DateTime, Rpt.Fecha)
            'db.AddParameter(cmd, "MENSAJE", DbType.String, 300, ParameterDirection.InputOutput, True, 0, 0, "", DataRowVersion.Default, Rpt.ValorxTexto)
            'db.ExecuteNonQuery(cmd)
            'lResult.ValorxTexto = Convert.ToString(db.GetParameterValue(cmd, "MENSAJE"))
            Return db.ExecuteDataSet(cmd).Tables(0).Rows(0)(0)
        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult.ValorxTexto.ToString

    End Function

    Public Function validarUserRevision(ByVal Rpt As ETEntregas) As DataTable
        'ByVal Rpt As ETEntregas


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VALIDARUSUARIOREVISION)

        Try
            db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarSolicitudesCero(ByVal Rpt As ETEntregas) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Listar_SolicitudesCero)
        Dim lResult As ETMyLista = Nothing
        Try
            db.AddInParameter(cmd, "cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Entregas = New ETEntregas
                    With Entidad.Entregas
                        .NumSolicitud = dr.GetString(dr.GetOrdinal("numsolicitud"))
                        .NomTrabajador = dr.GetString(dr.GetOrdinal("nomTrabajador"))
                        .Motivo = dr.GetString(dr.GetOrdinal("motivo"))
                        .montoTotal = dr.GetDecimal(dr.GetOrdinal("total"))
                        .Estado = dr.GetString(dr.GetOrdinal("estado"))
                        .FechaIngreso = dr.GetDateTime(dr.GetOrdinal("fechacrea"))
                        .codArea = dr.GetString(dr.GetOrdinal("codarea"))
                        .Usuario = dr.GetString(dr.GetOrdinal("usuario"))
                        .moneda = dr.GetString(dr.GetOrdinal("moneda"))
                        .flgpermiso = dr.GetInt32(dr.GetOrdinal("flgpermiso"))
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

    Public Function ValidaDocRepetido(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VALIDADOCREPETIDO)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "@TIPODOC", DbType.String, Rpt.TipoDoc)
            db.AddInParameter(cmd, "@NUMDOC", DbType.String, Rpt.NumDoc)
            db.AddInParameter(cmd, "@NRORUC", DbType.String, Rpt.nroruc)
            db.AddInParameter(cmd, "@TIPOTABLA", DbType.Int32, Rpt.tipotabla)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function VerAuxi3(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VerAuxi3)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AYO", DbType.String, Rpt.Anho)
            db.AddInParameter(cmd, "@CODCONCEPTO", DbType.String, Rpt.codConcepto)
            db.AddInParameter(cmd, "@CODAREA", DbType.String, Rpt.codArea)
            'db.AddInParameter(cmd, "@NRORUC", DbType.String, Rpt.nroruc)
            'db.AddInParameter(cmd, "@TIPOTABLA", DbType.Int32, Rpt.tipotabla)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function VerAuxi3Log(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VerAuxi3Log)
        Dim lResult As ETMyLista = Nothing

        Try
            'db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@TIPO", DbType.String, 1)
            db.AddInParameter(cmd, "@COD_AREA", DbType.String, Rpt.codArea)
            'db.AddInParameter(cmd, "@NRORUC", DbType.String, Rpt.nroruc)
            'db.AddInParameter(cmd, "@TIPOTABLA", DbType.Int32, Rpt.tipotabla)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Cantera_Maquina(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Cantera_Maquina)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@cod_equipo", DbType.String, Rpt.codAuxiliar)
            db.AddInParameter(cmd, "@AYO", DbType.String, Rpt.Anho)
            db.AddInParameter(cmd, "@MES", DbType.String, Rpt.Mes)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Movilidad_Fecha(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Movilidad_Fecha)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CODTRABAJADOR", DbType.String, Rpt.CodTrabajador)
            db.AddInParameter(cmd, "@NUMSOLCITUD", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "@FECHA", DbType.Date, Rpt.Fecha)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function verifica_documento_compra(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.verifica_documento_compra)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@TD", DbType.String, Rpt.TipoDoc)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function lista_registro_compra(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.lista_registro_compra)
        cmd.CommandTimeout = 0
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function usuario_registro_compra(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.usuario_registro_compra)
        cmd.CommandTimeout = 0
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function registra_retencion(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.registra_retencion)
        cmd.CommandTimeout = 0
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@IDLIQUIDACIONDET", DbType.String, Rpt.idComp)
            db.AddInParameter(cmd, "@NRORUC", DbType.String, Rpt.nroruc)
            db.AddInParameter(cmd, "@NUMDOC", DbType.String, Rpt.NumDoc)
            db.AddInParameter(cmd, "@MONTOTOTAL", DbType.Decimal, Rpt.montoTotal)
            db.AddInParameter(cmd, "@RAZON", DbType.String, Rpt.Razon)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function elimina_retencion(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.elimina_retencion)
        cmd.CommandTimeout = 0
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@IDLIQUIDACIONDET", DbType.String, Rpt.idComp)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function registro_compra(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.registro_compra)
        cmd.CommandTimeout = 0
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "@FECHA_PROCESO", DbType.DateTime, Rpt.fechaComp)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function registro_compra_Prov(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.registro_compra_Prov)
        cmd.CommandTimeout = 0
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "@FECHA_PROCESO", DbType.DateTime, Rpt.fechaComp)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function elimina_registro_compra(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.elimina_registro_compra)
        cmd.CommandTimeout = 0
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ValidaReintegroAplicacion(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VERIFICA_REINTEGROAPLICACION)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function CombustibleResumen(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.COMBUSTIBLERESUMEN)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            db.AddInParameter(cmd, "@CODTRABAJADOR", DbType.String, Rpt.CodTrabajador)
            db.AddInParameter(cmd, "@FECHA1", DbType.DateTime, Rpt.FechaInicio)
            db.AddInParameter(cmd, "@FECHA2", DbType.DateTime, Rpt.FechaTerminacion)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function EliminaProvisionEntregas(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ELIMINAPROVENTREGAS)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AÑOCONTABLE", DbType.Int32, Rpt.año)
            db.AddInParameter(cmd, "@MESCONTABLE", DbType.Int32, Rpt.Mes)
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function verificaProvisionMes(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.VERIFICAPROVISION)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@CIA", DbType.String, Companhia)
            db.AddInParameter(cmd, "@AÑOCONTABLE", DbType.Int32, Rpt.añocontable)
            db.AddInParameter(cmd, "@MESCONTABLE", DbType.Int32, Rpt.mescontable)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function usuarioRevision(ByVal Rpt As ETEntregas) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.usuarioRevision)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@USUARIO", DbType.String, Rpt.Usuario)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListarTransportista() As ETMyLista
        'ByVal Rpt As ETEntregas
        Dim lResult As ETMyLista = Nothing
        'If Rpt Is Nothing Then
        '    Return lResult
        'End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarTransportista)
        Dim CONT As Int32 = 0
        Dim objEntregas As New ETEntregas
        Dim Ls_Entrega_ As New List(Of ETEntregas)

        Try
            db.AddInParameter(cmd, "xcia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "usuario", DbType.String, Rpt.Usuario)
            'db.AddInParameter(cmd, "codarea", DbType.String, Rpt.codArea)
            lResult = New ETMyLista
            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    objEntregas = New ETEntregas
                    With objEntregas
                        CONT += 1
                        .codmotivoDetalle = dr.GetString(dr.GetOrdinal("cod_prov").ToString.Trim)
                        .motivoDetalle = dr.GetString(dr.GetOrdinal("razsoc").ToString.Trim)
                        .nroruc = dr.GetString(dr.GetOrdinal("ruc").ToString.Trim)
                    End With
                    'If CONT = 5000 Then
                    '    MsgBox("")
                    'End If
                    Ls_Entrega_.Add(objEntregas)
                    'lResult.Ls_Entrega.Add(objEntregas)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
                lResult.Ls_Entrega = Ls_Entrega_
            End Using

        Catch Err As Exception
            MsgBox(CONT)
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function

    Public Function ListarTransportista_() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarTransportista)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "xcia", DbType.String, Companhia)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function ListaPrudctoIQBF() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.LISTAPRODUCTOIQBF)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@COD_CIA", DbType.String, Companhia)
            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function


    Public Function ConceptosRH() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.CONCEPTORH)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
            'db.AddInParameter(cmd, "TIPO", DbType.Int32, Rpt.Tipo)
            'db.AddInParameter(cmd, "CODTRABAJADOR", DbType.String, Rpt.CodTrabajador)
            'db.AddInParameter(cmd, "FECHAINI", DbType.Date, Rpt.FechaInicio)
            'db.AddInParameter(cmd, "FECHAFIN", DbType.Date, Rpt.FechaTerminacion)
            'db.AddInParameter(cmd, "TIPOFILTRO", DbType.String, Rpt.tipofiltro)
            'db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
            'db.AddInParameter(cmd, "TIPOIMPRESION", DbType.Int32, Rpt.TipoImpresion)
            'db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConceptosRH = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarConceptoRH() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.LISTARCONCEPTORH)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            'db.AddInParameter(cmd, "CIA", DbType.String, Companhia)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarConceptoRH = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function EliminaLiquidacion(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.EliminaLiquidacion)

                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "NUMSOLICITUD", DbType.String, Rpt.NumSolicitud)
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

    Public Function MantenimientoAlquilerVehiculo(ByVal Rpt As ETEntregas) As ETEntregas

        Dim lResult As ETEntregas = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETEntregas

                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantenimientoAlquilerVehiculo)
                db.AddInParameter(cmd, "TIPO", DbType.String, Rpt.Tipo)
                db.AddInParameter(cmd, "ID", DbType.String, Rpt.ID)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "CODPROV", DbType.String, Rpt.codprov)
                db.AddInParameter(cmd, "RAZON", DbType.String, Rpt.Razon)
                db.AddInParameter(cmd, "PLACA", DbType.String, Rpt.placa)
                db.AddInParameter(cmd, "TVEHICULO", DbType.String, Rpt.tvehiculo)
                db.AddInParameter(cmd, "TFACTURACION", DbType.String, Rpt.tfacturacion)
                db.AddInParameter(cmd, "MONEDA", DbType.String, Rpt.moneda)
                db.AddInParameter(cmd, "IMPORTE", DbType.Double, Rpt.montoTotal)
                db.AddInParameter(cmd, "FECHAINICIO", DbType.DateTime, Rpt.FechaInicio)
                db.AddInParameter(cmd, "FLGCOMBUSTIBLE", DbType.Int32, Rpt.flgcombustible)
                db.AddInParameter(cmd, "FLGOPERADOR", DbType.Int32, Rpt.flgoperador)
                db.AddInParameter(cmd, "DESCRIPCION", DbType.String, Rpt.Descripcion)
                db.AddInParameter(cmd, "OBSERVACION", DbType.String, Rpt.Observacion)
                db.AddInParameter(cmd, "USUARIO", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

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


    Public Function FechaKilometraje() As ETEntregas

        Dim lResult As ETEntregas = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try
                lResult = New ETEntregas
                Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.Kilometraje_Fecha)
                db.AddOutParameter(cmd, "Respuesta", DbType.String, 10)
                db.ExecuteNonQuery(cmd)
                lResult.ValorxEntero = db.GetParameterValue(cmd, "Respuesta")
                lResult.Validacion = Boolean.TrueString
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                lResult = Nothing
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using
        Return lResult

    End Function

End Class
