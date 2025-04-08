Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAActivo

    Public Function ConsultarActivo(ByVal A As ETActivo) As List(Of ETActivo)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)
        Dim lst As New List(Of ETActivo)
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, A.Tipo)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodInterno", DbType.String, A.CodInterno)
            db.AddInParameter(cmd, "CodClase", DbType.String, A.CodClase)
            db.AddInParameter(cmd, "Placa", DbType.String, A.Placa)
            db.AddInParameter(cmd, "CodTipo", DbType.String, A.CodTipo)
            db.AddInParameter(cmd, "Descripcion", DbType.String, A.Descripcion)
            db.AddInParameter(cmd, "CodEnlace", DbType.String, A.CodEnlace)


            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.Placa = dr.GetString(dr.GetOrdinal("Placa"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    lst.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst
    End Function
    Public Function ConsultarActivoxMatriz(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodClase", DbType.String, Rpt.CodClase)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Rpt.CodEnlace)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Activo = New ETActivo
                    With Entidad.Activo
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                        .CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                        .Placa = dr.GetString(dr.GetOrdinal("Placa"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Rendimiento = dr.GetDecimal(dr.GetOrdinal("Rendimiento"))
                        .Energia = dr.GetDecimal(dr.GetOrdinal("Energia"))
                    End With
                    lResult.Ls_Activo.Add(Entidad.Activo)
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
    Public Function MantenimientoxMatrizxActivo(ByVal Rpt As ETActivo, ByVal Ls_Activo As List(Of ETActivo)) As ETActivo

        Dim lResult As ETActivo = Nothing
        If Rpt Is Nothing OrElse Ls_Activo Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETActivo

                For Each Row As ETActivo In Ls_Activo

                    Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxMatrizxActivo)

                    db.AddInParameter(cmd, "CodClase", DbType.String, Row.CodClase)
                    db.AddInParameter(cmd, "CodTipo", DbType.String, Row.CodTipo)
                    db.AddInParameter(cmd, "Placa", DbType.String, Row.Placa)
                    db.AddInParameter(cmd, "CodEnlace", DbType.Int32, Rpt.CodEnlace)
                    db.AddInParameter(cmd, "Rendimiento", DbType.Decimal, Row.Rendimiento)
                    db.AddInParameter(cmd, "Energia", DbType.Decimal, Row.Energia)
                    db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(cmd, Trans)

                    Entidad.Activo = New ETActivo
                    Entidad.Activo.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                    If Entidad.Activo.Respuesta <> 0 Then Err.Raise(10)

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
    Public Function ConsultarCronograma(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarCronograma)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodClase", DbType.String, Rpt.CodClase)
            db.AddInParameter(cmd, "Anho", DbType.Int32, Rpt.Anho)
            db.AddInParameter(cmd, "Semana", DbType.Int16, Rpt.Semana)
            db.AddInParameter(cmd, "dia", DbType.Int16, Rpt.Dia)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Activo = New ETActivo
                    Entidad.Activo.CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                    Entidad.Activo.CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                    Entidad.Activo.Placa = dr.GetString(dr.GetOrdinal("Placa"))
                    Entidad.Activo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Activo.Turno1 = dr.GetBoolean(dr.GetOrdinal("Turno1"))
                    Entidad.Activo.Turno2 = dr.GetBoolean(dr.GetOrdinal("Turno2"))
                    Entidad.Activo.Turno3 = dr.GetBoolean(dr.GetOrdinal("Turno3"))
                    Entidad.Activo.Turno4 = dr.GetBoolean(dr.GetOrdinal("Turno4"))
                    lResult.Ls_Activo.Add(Entidad.Activo)
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
    Public Function ConsultarCronogramaxPersonal(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarCronograma)

        Try

            lResult = New ETMyLista

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 3)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodClase", DbType.String, Rpt.CodClase)
            db.AddInParameter(cmd, "CodTipo", DbType.String, Rpt.CodTipo)
            db.AddInParameter(cmd, "Placa", DbType.String, Rpt.Placa)
            db.AddInParameter(cmd, "Anho", DbType.Int32, Rpt.Anho)
            db.AddInParameter(cmd, "Semana", DbType.Int16, Rpt.Semana)
            db.AddInParameter(cmd, "dia", DbType.Int16, Rpt.Dia)
            db.AddInParameter(cmd, "Turno", DbType.Int16, Rpt.Turno)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    Entidad.Personal.Turno = Rpt.Turno
                    Select Case Rpt.Turno
                        Case 1
                            Entidad.Personal.DesTurno = "PRIMER TURNO"
                        Case 2
                            Entidad.Personal.DesTurno = "SEGUNDO TURNO"
                        Case 3
                            Entidad.Personal.DesTurno = "TERCER TURNO"
                        Case Else
                            Entidad.Personal.DesTurno = "HORARIO NORMAL"
                    End Select
                    Entidad.Personal.CodUnidadProd = Rpt.Placa
                    Entidad.Personal.CodPersonal = dr.GetString(dr.GetOrdinal("CodPersonal"))
                    Entidad.Personal.DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                    lResult.Ls_Personal.Add(Entidad.Personal)
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
    Public Function MantenimientoxCronograma(ByVal Rpt As ETActivo, ByVal Ls_Personal As List(Of ETPersonal)) As ETActivo

        Dim lResult As ETActivo = Nothing
        If Rpt Is Nothing OrElse Ls_Personal Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETActivo

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxCronograma)
                db.AddInParameter(cmd, "cod_cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                db.AddInParameter(cmd, "Anho", DbType.Int32, Rpt.Anho)
                db.AddInParameter(cmd, "Semana", DbType.Int16, Rpt.Semana)
                db.AddInParameter(cmd, "dia", DbType.Int16, Rpt.Dia)
                db.AddInParameter(cmd, "Fecha", DbType.Date, Rpt.Fecha.Date)
                db.AddInParameter(cmd, "Turno", DbType.Int16, Rpt.Turno)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.AddOutParameter(cmd, "Valor", DbType.Int32, 11)

                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                lResult.ID = Convert.ToInt32(db.GetParameterValue(cmd, "Valor"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

                Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxCronograma)
                db.AddInParameter(xmd, "cod_cia", DbType.String, Companhia)
                db.AddInParameter(xmd, "Fecha", DbType.Date, Rpt.Fecha.Date)
                db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                db.AddInParameter(xmd, "ID", DbType.Int32, lResult.ID)
                db.AddInParameter(xmd, "CodClase", DbType.String, Rpt.CodClase)
                db.AddInParameter(xmd, "CodTipo", DbType.String, Rpt.CodTipo)
                db.AddInParameter(xmd, "Placa", DbType.String, Rpt.Placa)
                db.AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                db.AddOutParameter(xmd, "Valor", DbType.Int32, 11)

                db.ExecuteNonQuery(xmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))
                lResult.ID = Convert.ToInt32(db.GetParameterValue(xmd, "Valor"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

                For Each Row As ETPersonal In Ls_Personal

                    Dim zmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxCronograma)
                    db.AddInParameter(zmd, "cod_cia", DbType.String, Companhia)
                    db.AddInParameter(zmd, "Fecha", DbType.Date, Rpt.Fecha.Date)
                    db.AddInParameter(zmd, "Tipo", DbType.Int16, 3)
                    db.AddInParameter(zmd, "ID", DbType.Int32, lResult.ID)
                    db.AddInParameter(zmd, "CodPersonal", DbType.String, Row.CodPersonal)
                    db.AddInParameter(zmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(zmd, "Respuesta", DbType.Int16, 10)

                    db.ExecuteNonQuery(zmd, Trans)

                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(zmd, "Respuesta"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)
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

    Public Function MantenimientoxCronogramaxSemana(ByVal Rpt As ETActivo, ByVal Ls_Personal As List(Of ETPersonal)) As ETActivo

        Dim lResult As ETActivo = Nothing
        Dim Dia As Integer = 1
        If Rpt Is Nothing OrElse Ls_Personal Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Rpt.Fecha = Rpt.FechaInicio.Date
                While Rpt.Fecha.Date <= Rpt.FechaTerminacion.Date
                    Rpt.Dia = Dia

                    lResult = New ETActivo

                    Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxCronograma)
                    db.AddInParameter(cmd, "cod_cia", DbType.String, Companhia)
                    db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                    db.AddInParameter(cmd, "Anho", DbType.Int32, Rpt.Anho)
                    db.AddInParameter(cmd, "Semana", DbType.Int16, Rpt.Semana)
                    db.AddInParameter(cmd, "dia", DbType.Int16, Rpt.Dia)
                    db.AddInParameter(cmd, "Fecha", DbType.Date, Rpt.Fecha.Date)
                    db.AddInParameter(cmd, "Turno", DbType.Int16, Rpt.Turno)
                    db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                    db.AddOutParameter(cmd, "Valor", DbType.Int32, 11)

                    db.ExecuteNonQuery(cmd, Trans)

                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                    lResult.ID = Convert.ToInt32(db.GetParameterValue(cmd, "Valor"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)

                    Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxCronograma)
                    db.AddInParameter(xmd, "cod_cia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "Fecha", DbType.Date, Rpt.Fecha.Date)
                    db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                    db.AddInParameter(xmd, "ID", DbType.Int32, lResult.ID)
                    db.AddInParameter(xmd, "CodClase", DbType.String, Rpt.CodClase)
                    db.AddInParameter(xmd, "CodTipo", DbType.String, Rpt.CodTipo)
                    db.AddInParameter(xmd, "Placa", DbType.String, Rpt.Placa)
                    db.AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.AddOutParameter(xmd, "Valor", DbType.Int32, 11)

                    db.ExecuteNonQuery(xmd, Trans)

                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))
                    lResult.ID = Convert.ToInt32(db.GetParameterValue(xmd, "Valor"))

                    If lResult.Respuesta <> 0 Then Err.Raise(10)

                    For Each Row As ETPersonal In Ls_Personal

                        Dim zmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoxCronograma)
                        db.AddInParameter(zmd, "cod_cia", DbType.String, Companhia)
                        db.AddInParameter(zmd, "Fecha", DbType.Date, Rpt.Fecha.Date)
                        db.AddInParameter(zmd, "Tipo", DbType.Int16, 3)
                        db.AddInParameter(zmd, "ID", DbType.Int32, lResult.ID)
                        db.AddInParameter(zmd, "CodPersonal", DbType.String, Row.CodPersonal)
                        db.AddInParameter(zmd, "Usuario", DbType.String, Rpt.Usuario)
                        db.AddOutParameter(zmd, "Respuesta", DbType.Int16, 10)

                        db.ExecuteNonQuery(zmd, Trans)

                        lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(zmd, "Respuesta"))

                        If lResult.Respuesta <> 0 Then Err.Raise(10)
                    Next

                    lResult.Validacion = Boolean.TrueString


                    Dia = Dia + 1
                    Rpt.Fecha = DateAdd(DateInterval.Day, 1, Rpt.Fecha)
                End While
                
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


    Public Function CuadroDisponUnidad(ByVal A As ETActivo) As List(Of ETActivo)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CuadroDisponUnidad)
        Dim lst As New List(Of ETActivo)
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "FechaInicio", DbType.Date, A.FechaInicio)
            db.AddInParameter(cmd, "FechaFinal", DbType.Date, A.FechaFinal)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                    E.CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                    E.Placa = dr.GetString(dr.GetOrdinal("Placa"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    E.Turno = dr.GetInt16(dr.GetOrdinal("Turno"))
                    E.Miercoles = dr.GetBoolean(dr.GetOrdinal("Miercoles"))
                    E.Jueves = dr.GetBoolean(dr.GetOrdinal("Jueves"))
                    E.Viernes = dr.GetBoolean(dr.GetOrdinal("Viernes"))
                    E.Sabado = dr.GetBoolean(dr.GetOrdinal("Sabado"))
                    E.Domingo = dr.GetBoolean(dr.GetOrdinal("Domingo"))
                    E.Lunes = dr.GetBoolean(dr.GetOrdinal("Lunes"))
                    E.Martes = dr.GetBoolean(dr.GetOrdinal("Martes"))
                    E.dtMiercoles = dr.GetDateTime(dr.GetOrdinal("dtMiercoles"))
                    E.dtJueves = dr.GetDateTime(dr.GetOrdinal("dtJueves"))
                    E.dtViernes = dr.GetDateTime(dr.GetOrdinal("dtViernes"))
                    E.dtSabado = dr.GetDateTime(dr.GetOrdinal("dtSabado"))
                    E.dtDomingo = dr.GetDateTime(dr.GetOrdinal("dtDomingo"))
                    E.dtLunes = dr.GetDateTime(dr.GetOrdinal("dtLunes"))
                    E.dtMartes = dr.GetDateTime(dr.GetOrdinal("dtMartes"))
                    lst.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst
    End Function
    Public Function ConsultarActivo4() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read
                    Entidad.Activo = New ETActivo
                    With Entidad.Activo
                        .CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                        .CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                        .Placa = dr.GetString(dr.GetOrdinal("Placa"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    End With
                    lResult.Ls_Activo.Add(Entidad.Activo)
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
    Public Function MantenimientoUnidadPersonal(ByVal Rpt As ETActivo, ByVal Ls_Personal As List(Of ETPersonal)) As ETActivo

        Dim lResult As ETActivo = Nothing
        If Rpt Is Nothing OrElse Ls_Personal Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETActivo

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoUnidadPersonal)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
                db.AddInParameter(cmd, "CodClase", DbType.String, Rpt.CodClase)
                db.AddInParameter(cmd, "CodTipo", DbType.String, Rpt.CodTipo)
                db.AddInParameter(cmd, "Placa", DbType.String, Rpt.Placa)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                If lResult.Respuesta <> 0 Then Err.Raise(10)

                For Each Row As ETPersonal In Ls_Personal

                    Dim zmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoUnidadPersonal)

                    db.AddInParameter(zmd, "Tipo", DbType.Int16, 1)
                    db.AddInParameter(zmd, "CodClase", DbType.String, Rpt.CodClase)
                    db.AddInParameter(zmd, "CodTipo", DbType.String, Rpt.CodTipo)
                    db.AddInParameter(zmd, "Placa", DbType.String, Rpt.Placa)
                    db.AddInParameter(zmd, "CodPersonal", DbType.String, Row.CodPersonal)
                    db.AddInParameter(zmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(zmd, "Respuesta", DbType.Int16, 10)

                    db.ExecuteNonQuery(zmd, Trans)

                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(zmd, "Respuesta"))
                    If lResult.Respuesta <> 0 Then Err.Raise(10)

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
    Public Function ConsultarActivo5(ByVal Rpt As ETActivo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 5)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodClase", DbType.String, Rpt.CodClase)
            db.AddInParameter(cmd, "CodTipo", DbType.String, Rpt.CodTipo)
            db.AddInParameter(cmd, "Placa", DbType.String, Rpt.Placa)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    Entidad.Personal.CodPersonal = dr.GetString(dr.GetOrdinal("CodPersonal"))
                    Entidad.Personal.DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                    lResult.Ls_Personal.Add(Entidad.Personal)
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
    Public Function ConsultarActivo6(ByVal A As ETActivo) As List(Of ETActivo)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)
        Dim lst As New List(Of ETActivo)
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 6)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodClase", DbType.String, A.CodClase)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                    E.CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                    E.Placa = dr.GetString(dr.GetOrdinal("Placa"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    E.Turno1 = dr.GetBoolean(dr.GetOrdinal("Turno1"))
                    E.Turno2 = dr.GetBoolean(dr.GetOrdinal("Turno2"))
                    E.Turno3 = dr.GetBoolean(dr.GetOrdinal("Turno3"))
                    E.Turno4 = dr.GetBoolean(dr.GetOrdinal("Turno4"))
                    lst.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst
    End Function
    Public Function MantenimientoPlanilla(ByVal A As ETActivo, ByVal P As List(Of ETPersonal)) As ETObjecto

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim O As ETObjecto = Nothing

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoPlanilla)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                db.AddInParameter(cmd, "CodClase", DbType.String, A.CodClase)
                db.AddInParameter(cmd, "CodTipo", DbType.String, A.CodTipo)
                db.AddInParameter(cmd, "Placa", DbType.String, A.Placa)
                db.AddInParameter(cmd, "Turno", DbType.Int32, A.Turno)
                db.AddInParameter(cmd, "Usuario", DbType.String, A.Usuario)
                db.AddOutParameter(cmd, "ID", DbType.Int32, 11)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                O = New ETObjecto

                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                O.ID = Convert.ToInt32(db.GetParameterValue(cmd, "ID"))

                If O.Respuesta <> 0 OrElse O.ID = 0 Then
                    Err.Raise(10)
                End If

                For Each W As ETPersonal In P

                    Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoPlanilla)

                    db.AddInParameter(xmd, "Tipo", DbType.Int16, 2)
                    db.AddInParameter(xmd, "ID", DbType.Int32, O.ID)
                    db.AddInParameter(xmd, "CodClase", DbType.String, A.CodClase)
                    db.AddInParameter(xmd, "CodTipo", DbType.String, A.CodTipo)
                    db.AddInParameter(xmd, "Placa", DbType.String, A.Placa)
                    db.AddInParameter(xmd, "Turno", DbType.Int32, A.Turno)
                    db.AddInParameter(xmd, "CodPersonal", DbType.String, W.CodPersonal)
                    db.AddInParameter(xmd, "Usuario", DbType.String, A.Usuario)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)
                    db.ExecuteNonQuery(xmd, Trans)

                    O.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))

                    If O.Respuesta <> 0 Then
                        Err.Raise(10)
                    End If

                Next

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

                Return Nothing

            End Try

            Trans.Commit()
            Conexion.Close()

        End Using

        Return O

    End Function
    Public Function ConsultarActivo7(ByVal A As ETActivo) As List(Of ETPersonal)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)
        Dim lst As New List(Of ETPersonal)
        Dim E As ETPersonal = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 7)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodClase", DbType.String, A.CodClase)
            db.AddInParameter(cmd, "CodTipo", DbType.String, A.CodTipo)
            db.AddInParameter(cmd, "Placa", DbType.String, A.Placa)
            db.AddInParameter(cmd, "Turno", DbType.Int32, A.Turno)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETPersonal
                    E.CodPersonal = dr.GetString(dr.GetOrdinal("CodPersonal"))
                    E.DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                    lst.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst

    End Function

    Public Function ConsultarActivo8(ByVal A As ETActivo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)
        Dim lst As New ETMyLista
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 8)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Equipo", DbType.Int32, A.Activo)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.CodClase = dr.GetString(dr.GetOrdinal("Clase"))
                    E.CodTipo = dr.GetString(dr.GetOrdinal("Tipo"))
                    E.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    lst.Ls_Activo.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If
                lst.Validacion = True

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst
    End Function

    Public Function ConsultarActivo9() As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)
        Dim lst As New ETMyLista
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 9)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.CodClase = dr.GetString(dr.GetOrdinal("Clase"))
                    E.CodTipo = dr.GetString(dr.GetOrdinal("Tipo"))
                    E.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    lst.Ls_Activo.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If
                lst.Validacion = True

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst
    End Function

    Public Function ConsultarActivo10() As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarActivos)
        Dim lst As New ETMyLista
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 10)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.CodClase = dr.GetString(dr.GetOrdinal("Clase"))
                    E.CodTipo = dr.GetString(dr.GetOrdinal("Tipo"))
                    E.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    lst.Ls_Activo.Add(E)

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If
                lst.Validacion = True

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst
    End Function


    Public Function ImportarCronograma(ByVal A As ETActivo) As ETObjecto

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim O As ETObjecto = Nothing

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ImportarCronograma)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, A.Tipo)
                db.AddInParameter(cmd, "Anho", DbType.Int32, A.Anho)
                db.AddInParameter(cmd, "Semana", DbType.Int16, A.Semana)
                db.AddInParameter(cmd, "SemanaPrevia", DbType.Int16, A.SemanaPrevia)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, A.FechaInicio)
                db.AddInParameter(cmd, "Rotar1", DbType.Int16, A.Rotar1)
                db.AddInParameter(cmd, "Rotar2", DbType.Int16, A.Rotar2)
                db.AddInParameter(cmd, "Rotar3", DbType.Int16, A.Rotar3)
                db.AddInParameter(cmd, "Usuario", DbType.String, A.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                O = New ETObjecto

                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If O.Respuesta <> 0 Then
                    Err.Raise(10)
                End If

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

                Return Nothing

            End Try

            Trans.Commit()
            Conexion.Close()

        End Using

        Return O

    End Function
    Public Function ConsultarExisteCronograma(ByVal A As ETActivo) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarCronograma)
        Dim lst As New List(Of ETActivo)
        Dim E As ETActivo = Nothing
        Dim O As ETObjecto = Nothing
        Try
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)
            db.AddInParameter(cmd, "Anho", DbType.Int32, A.Anho)
            db.AddInParameter(cmd, "Semana", DbType.Int16, A.Semana)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

            db.ExecuteNonQuery(cmd)

            O = New ETObjecto

            O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return O

    End Function
    Public Function CuadroxOrdenxUnidad(ByVal P As ETProducto, ByVal A As ETActivo) As ETActivo

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CuadroxOrdenxUnidad)
        Dim E As ETActivo = Nothing

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEnlace", DbType.Int32, P.ID)
            db.AddInParameter(cmd, "CodProducto", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "CodClase", DbType.String, A.CodClase)
            db.AddInParameter(cmd, "CodTipo", DbType.String, A.CodTipo)
            db.AddInParameter(cmd, "Placa", DbType.String, A.Placa)
            db.AddInParameter(cmd, "Cantidad", DbType.Decimal, P.Cantidad)
            db.AddInParameter(cmd, "Horas", DbType.Decimal, A.Horas)
            db.AddInParameter(cmd, "Fecha", DbType.Date, A.Fecha)
            db.AddInParameter(cmd, "Turno", DbType.Int16, A.Turno)


            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETActivo
                    E.ID = dr.GetInt32(dr.GetOrdinal("ID"))
                    E.CodLote = dr.GetString(dr.GetOrdinal("CodLote"))
                    E.CodClase = dr.GetString(dr.GetOrdinal("CodClase"))
                    E.CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                    E.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    E.Turno = dr.GetInt16(dr.GetOrdinal("Turno"))
                    E.Placa = dr.GetString(dr.GetOrdinal("Placa"))
                    E.Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                    E.Horas = dr.GetDecimal(dr.GetOrdinal("Horas"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    E.Rendimiento = dr.GetDecimal(dr.GetOrdinal("Rendimiento"))
                    E.Energia = dr.GetDecimal(dr.GetOrdinal("Energia"))
                    E.NroOperarios = dr.GetInt16(dr.GetOrdinal("NroOperarios"))
                    E.CostoPromxHora = dr.GetDecimal(dr.GetOrdinal("CostoPromxHora"))
                    E.CostoKwxHora = dr.GetDecimal(dr.GetOrdinal("CostoKwxHora"))
                    E.MODhhxtn = dr.GetDecimal(dr.GetOrdinal("MODhhxtn"))
                    E.MODSolxtn = dr.GetDecimal(dr.GetOrdinal("MODSolxtn"))
                    E.EnergiaSolxtn = dr.GetDecimal(dr.GetOrdinal("EnergiaSolxtn"))
                    E.CostoxTon = dr.GetDecimal(dr.GetOrdinal("CostoxTon"))
                    E.TonMaximo = dr.GetDecimal(dr.GetOrdinal("TonMaximo"))

                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return E

    End Function

    Public Function Reporte_Cronograma(ByVal Rpt As ETActivo, ByVal pIdPlanta As Int16) As ETActivo

        Dim lResult As ETActivo = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarCronograma)
        Dim Ds As DataSet = Nothing
        Dim Tabla As DataTable = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 5)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Anho", DbType.Int32, Rpt.Anho)
            db.AddInParameter(cmd, "Semana", DbType.Int16, Rpt.Semana)
            db.AddInParameter(cmd, "dia", DbType.Int16, Rpt.Dia)
            db.AddInParameter(cmd, "IdPlanta", DbType.Int16, pIdPlanta)


            lResult = New ETActivo

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            If Tabla.Rows.Count > 0 Then
                lResult.Tabla = Tabla.Copy
                lResult.Validacion = Boolean.TrueString
            End If

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        Finally

            If Tabla IsNot Nothing Then Tabla = Nothing
            If Ds IsNot Nothing Then Ds = Nothing

        End Try

        Return lResult

    End Function

    Public Function ConsultarCronograma6(ByVal Rpt As ETActivo, ByVal pIdPlanta As Int16) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarCronograma)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 6)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Anho", DbType.Int32, Rpt.Anho)
            db.AddInParameter(cmd, "Semana", DbType.Int16, Rpt.Semana)
            db.AddInParameter(cmd, "dia", DbType.Int16, Rpt.Dia)
            db.AddInParameter(cmd, "IdPlanta", DbType.Int16, pIdPlanta)


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Activo = New ETActivo
                    Entidad.Activo.Placa = dr.GetString(dr.GetOrdinal("Placa"))
                    Entidad.Activo.CodTipo = dr.GetString(dr.GetOrdinal("CodTipo"))
                    Entidad.Activo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    lResult.Ls_Activo.Add(Entidad.Activo)
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


    Public Function ConsultarProgramacion_1(ByVal Rpt1 As ETActivo, ByVal Rpt2 As ETProducto) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt1 Is Nothing OrElse Rpt2 Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarProgramacion)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)

            db.AddInParameter(cmd, "CodClase", DbType.String, Rpt1.CodClase)
            db.AddInParameter(cmd, "CodTipo", DbType.String, Rpt1.CodTipo)
            db.AddInParameter(cmd, "CodProducto", DbType.String, Rpt2.CodProducto)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Rpt1.FechaInicio)
            db.AddInParameter(cmd, "FechaFinal", DbType.Date, Rpt1.FechaFinal)

            lResult = New ETMyLista

            lResult.Coleccion = db.ExecuteDataSet(cmd)

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

#Region "Listar Costeo Mineral"
    Public Function ListarCosteoMineral(ByVal Costeo As ETCanteraCosteo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand
        If Costeo.Tipo = "2" Then
            cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Comparacion)
        Else
            cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral)
        End If

        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try

                cmd.CommandTimeout = 500
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
                db.AddInParameter(cmd, "Mes", DbType.Int32, Costeo.Mes)
                db.AddInParameter(cmd, "Ano", DbType.Int32, Costeo.Ano)
                If Not (Costeo.Tipo = "2") Then
                    db.AddInParameter(cmd, "Contable", DbType.String, Costeo.Tipo)
                End If

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                ListarCosteoMineral = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

        
    End Function
    Public Function ListarCanterasCosteoMineral(ByVal Rpt As ETCanteraCosteo) As ETMyLista

        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ListarCanteras_CosteoMineral)

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Ano", DbType.Int32, Rpt.Ano)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Rpt.Mes)
            db.AddInParameter(cmd, "Contable", DbType.String, Rpt.Tipo)
            db.AddInParameter(cmd, "Tipo", DbType.String, Rpt.TipoTrabajo)
            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CanteraCosteo = New ETCanteraCosteo
                    Entidad.CanteraCosteo.CodigoCantera = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.CanteraCosteo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.CanteraCosteo.Tipo = dr.GetString(dr.GetOrdinal("Origen"))
                    Entidad.CanteraCosteo.Importe = dr.GetDecimal(dr.GetOrdinal("Costo"))
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


    Public Function ListarCosteoMineral_Save(ByVal Costeo As ETCanteraCosteo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand


        If Costeo.Tipo = "3" Then
            cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Comparacion)
        Else
            'cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Mineral)
            cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Mineral_2016)
        End If

        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try

               
                If Costeo.Action = False Then
                    Dim cmd1 As DbCommand
                    cmd1 = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Variacion_Guardar)
                    db.AddInParameter(cmd1, "ID", DbType.Int32, 0)
                    db.AddInParameter(cmd1, "Incremento", DbType.Decimal, 0)
                    db.AddInParameter(cmd1, "Tipo", DbType.Boolean, Costeo.Action)
                    db.ExecuteScalar(cmd1, Trans)
                Else
                    For Each xRow As DataRow In Costeo.DT_Lista.Rows
                        Dim cmd2 As DbCommand
                        cmd2 = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Variacion_Guardar)
                        db.AddInParameter(cmd2, "ID", DbType.Int32, xRow.Item("ID"))
                        db.AddInParameter(cmd2, "Incremento", DbType.Decimal, xRow.Item("Variacion"))
                        db.AddInParameter(cmd2, "Tipo", DbType.Boolean, Costeo.Action)
                        db.ExecuteScalar(cmd2, Trans)
                    Next
                End If

                cmd.CommandTimeout = 8000
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
                db.AddInParameter(cmd, "Mes", DbType.Int32, Costeo.Mes)
                db.AddInParameter(cmd, "Ano", DbType.Int32, Costeo.Ano)
                If Not (Costeo.Tipo = "3") Then
                    db.AddInParameter(cmd, "Contable", DbType.String, Costeo.Tipo)
                    db.AddInParameter(cmd, "Usuario", DbType.String, Costeo.User)
                Else
                    db.AddInParameter(cmd, "Incremento", DbType.Boolean, Costeo.Action)
                End If

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                ListarCosteoMineral_Save = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function

    Public Function ListarCosteoMineral_Minas(ByVal Costeo As ETCanteraCosteo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand

        cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Minas)

        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 8000
                db.AddInParameter(cmd, "AYO", DbType.Int32, Costeo.Ano)
                db.AddInParameter(cmd, "MES", DbType.Int32, Costeo.Mes)

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                ListarCosteoMineral_Minas = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function

    Public Function CosteoMineral_ValidarBilleteSinCantera(ByVal Costeo As ETCanteraCosteo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand

        cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_ValidarBilleteSinCantera)
      

        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try

                cmd.CommandTimeout = 500
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
                db.AddInParameter(cmd, "FechaInicio", DbType.Date, Costeo.FechaInicio.Date)
                db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Costeo.FechaFin)
               

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                CosteoMineral_ValidarBilleteSinCantera = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function

    Public Function CosteoMineral_Listar() As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand

        cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Listar)


        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try

                'cmd.CommandTimeout = 500
                'db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
                'db.AddInParameter(cmd, "FechaInicio", DbType.Date, Costeo.FechaInicio.Date)
                'db.AddInParameter(cmd, "FechaTermino", DbType.DateTime, Costeo.FechaFin)


                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                CosteoMineral_Listar = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function



    Public Function ListarCosteoMineralxCantera(ByVal Costeo As ETCanteraCosteo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand
        cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_xCantera)


        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try

                cmd.CommandTimeout = 500
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Costeo.Ano)
                db.AddInParameter(cmd, "Tipo", DbType.String, Costeo.Tipo)
                db.AddInParameter(cmd, "Reporte", DbType.String, Costeo.TipoTrabajo)

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                ListarCosteoMineralxCantera = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function

    Public Function ListarCosteoMineralxCanteraxRangos(ByVal Costeo As ETCanteraCosteo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand
        If Costeo.TipoTrabajo = "1" Then
            cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_xCantera_xRangos)
        Else
            cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_xTipoConcepto_xRangos)
        End If


        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try

                If Costeo.Action = False Then
                    Dim cmd1 As DbCommand
                    cmd1 = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Variacion_Guardar)
                    db.AddInParameter(cmd1, "ID", DbType.Int32, 0)
                    db.AddInParameter(cmd1, "Incremento", DbType.Decimal, 0)
                    db.AddInParameter(cmd1, "Tipo", DbType.Boolean, Costeo.Action)
                    db.ExecuteScalar(cmd1, Trans)
                Else
                    For Each xRow As DataRow In Costeo.DT_Lista.Rows
                        Dim cmd2 As DbCommand
                        cmd2 = db.GetStoredProcCommand(usp_RAL.CosteoMineral_Variacion_Guardar)
                        db.AddInParameter(cmd2, "ID", DbType.Int32, xRow.Item("ID"))
                        db.AddInParameter(cmd2, "Incremento", DbType.Decimal, xRow.Item("Variacion"))
                        db.AddInParameter(cmd2, "Tipo", DbType.Boolean, Costeo.Action)
                        db.ExecuteScalar(cmd2, Trans)
                    Next
                End If

                cmd.CommandTimeout = 500
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
                db.AddInParameter(cmd, "AnioIni", DbType.Int32, Costeo.Ano)
                db.AddInParameter(cmd, "MesIni", DbType.Int16, Costeo.Mes)
                db.AddInParameter(cmd, "AnioFin", DbType.Int32, Costeo.Ano_Fin)
                db.AddInParameter(cmd, "MesFin", DbType.Int16, Costeo.Mes_Fin)
                db.AddInParameter(cmd, "TipoInfo", DbType.String, Costeo.Tipo)
                db.AddInParameter(cmd, "TipoCantera", DbType.String, Costeo.TipoCantera)
                db.AddInParameter(cmd, "CostoView", DbType.String, Costeo.TipoCosto)
                db.AddInParameter(cmd, "Incremento", DbType.Boolean, Costeo.Action)

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                ListarCosteoMineralxCanteraxRangos = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function

    Public Function ListarCategoriaTrabajador(ByVal Costeo As ETCanteraCosteo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand

        cmd = db.GetStoredProcCommand(usp_RAL.ListarCategoriaTrabajador)

        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 8000
                'db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
                'db.AddInParameter(cmd, "Mes", DbType.Int32, Costeo.Mes)
                'db.AddInParameter(cmd, "Ano", DbType.Int32, Costeo.Ano)

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                ListarCategoriaTrabajador = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function


    Public Function ListarCategoriaTrabajadorMant(ByVal Costeo As ETCanteraCosteo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand

        cmd = db.GetStoredProcCommand(usp_RAL.ListarCategoriaTrabajadorMant)

        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                cmd.CommandTimeout = 8000
                db.AddInParameter(cmd, "@placod", DbType.String, Costeo.CodEmpleado)
                db.AddInParameter(cmd, "@idcategoria", DbType.Int32, Costeo.ID)
                db.AddInParameter(cmd, "@usuario", DbType.String, Costeo.User)

                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                ListarCategoriaTrabajadorMant = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function

#End Region

#Region "Ventas Mensual"
    Public Function ObtenerVentasMensual(ByVal Costeo As ETCanteraCosteo) As Double

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim lResul As Double = 0
        Dim cmd As DbCommand

        cmd = db.GetStoredProcCommand(usp_RAL.CosteoMineral_VentasMensual)


        Try
            cmd.CommandTimeout = 500
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Costeo.Ano)
            db.AddInParameter(cmd, "Mes", DbType.Int32, Costeo.Mes)
            lResul = db.ExecuteScalar(cmd)
            cmd.CommandTimeout = 0
        Catch Err As Exception
            cmd.CommandTimeout = 0
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResul = 0
        End Try
        Return lResul
    End Function
#End Region

#Region "Listar Detalle de Costeo de Minerales"
    Public Function ListarDetalleCosteoMineral(ByVal Costeo As ETCanteraCosteo, ByVal Opcion As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand
        If (Costeo.Tipo = "0" Or Costeo.Tipo = "2") And (Opcion = 4 Or Opcion = 6 Or Opcion = 7 Or _
            Opcion = 9 Or Opcion = 11 Or Opcion = 12 Or Opcion = 15 Or Opcion = 16 Or _
            Opcion = 17 Or Opcion = 18 Or Opcion = 53) Then 'Opcion = 8 Or
            'cmd = db.GetStoredProcCommand(usp_RAL.DetalleCosteoMineral_NoContable)
            cmd = db.GetStoredProcCommand(usp_RAL.DetalleCosteoMineral_NoContable_2016)
        ElseIf Costeo.Tipo = "3" And Opcion <> 1 Then
            cmd = db.GetStoredProcCommand(usp_RAL.DetalleCosteoMineral_Comparacion)
        Else
            'cmd = db.GetStoredProcCommand(usp_RAL.DetalleCosteoMineral)
            cmd = db.GetStoredProcCommand(usp_RAL.DetalleCosteoMineral_2016)
        End If

        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Costeo.CodCia)
            db.AddInParameter(cmd, "Cantera", DbType.String, Costeo.CodigoCantera)
            db.AddInParameter(cmd, "Mes", DbType.String, Costeo.Mes)
            db.AddInParameter(cmd, "Ano", DbType.String, Costeo.Ano)
            db.AddInParameter(cmd, "Tonelaje", DbType.Decimal, Costeo.NumeroPeriodo)
            db.AddInParameter(cmd, "Total", DbType.Decimal, Costeo.Importe)
            db.AddInParameter(cmd, "Tipo", DbType.String, Costeo.Tipo)
            db.AddInParameter(cmd, "Opcion", DbType.Int32, Opcion)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDetalleCosteoMineral = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ListarAgrupacion(ByVal TIPO As Int32, ByVal CODAGRUPACION As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand

        cmd = db.GetStoredProcCommand(usp_RAL.LISTAAGRUPACION)


        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try

                cmd.CommandTimeout = 500
                db.AddInParameter(cmd, "TIPO", DbType.Int32, TIPO)
                db.AddInParameter(cmd, "CIA", DbType.String, Companhia)
                db.AddInParameter(cmd, "CODAGRUPACION", DbType.String, CODAGRUPACION)


                Ds = New DataSet
                Ds = db.ExecuteDataSet(cmd, Trans)

                Tabla = New DataTable
                Tabla = Ds.Tables(0).Copy

                ListarAgrupacion = Tabla
                Trans.Commit()
                Conexion.Close()
                cmd.CommandTimeout = 0
            Catch Err As Exception
                cmd.CommandTimeout = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try

        End Using

    End Function
#End Region
    
End Class
