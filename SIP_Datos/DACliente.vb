Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DACliente
    Public Function Listar_Clientes_Activos() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Cliente)
        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.Cliente = New ETCliente
                    With Entidad.Cliente
                        .Codigo = dr.GetString(dr.GetOrdinal("Cod_Cli"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Cliente"))
                        .RUC = dr.GetString(dr.GetOrdinal("RUC"))
                    End With
                    lResult.Ls_Cliente.Add(Entidad.Cliente)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using
            Return lResult
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
    Public Function ListarExportacion(ByVal C As ETCliente) As List(Of ETCliente)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ListarExportacion)
        Dim lst As New List(Of ETCliente)
        Dim E As ETCliente = Nothing
        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, C.Tipo)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    E = New ETCliente
                    E.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
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

    Public Function ConsultaExportacion1() As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                If O.Respuesta <> 0 Then Err.Raise(10)
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using
        Return O
    End Function

    Public Function ConsultaExportacion2() As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                If O.Respuesta <> 0 Then Err.Raise(10)
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using
        Return O
    End Function

    Public Function ConsultaExportacion3(ByVal C As ETCliente) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 3)
                db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, C.FechaInicio)
                db.AddInParameter(cmd, "FechaFinal", DbType.DateTime, C.FechaFinal)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                If O.Respuesta <> 0 Then Err.Raise(10)
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using
        Return O
    End Function

    Public Function ConsultaExportacion4(ByVal C As ETCliente) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)
            db.AddInParameter(cmd, "Anho", DbType.Int32, C.Anho)
            db.AddInParameter(cmd, "Mes", DbType.Int32, C.Mes)
            db.AddInParameter(cmd, "Codigo", DbType.String, C.Codigo)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

            cmd.CommandTimeout = 0

            db.ExecuteNonQuery(cmd)

            O = New ETObjecto

            O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

            If O.Respuesta <> 0 Then
                Err.Raise(10)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return O
    End Function

    Public Function ConsultaExportacion5(ByVal C As ETCliente) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto

        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 5)
            db.AddInParameter(cmd, "Anho", DbType.Int32, C.Anho)
            db.AddInParameter(cmd, "Mes", DbType.Int32, C.Mes)
            db.AddInParameter(cmd, "Codigo", DbType.String, C.Codigo)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

            cmd.CommandTimeout = 0

            db.ExecuteNonQuery(cmd)

            O = New ETObjecto

            O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

            If O.Respuesta <> 0 Then
                Err.Raise(10)
            End If

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return O
    End Function

    Public Function ConsultaExportacion6(ByVal C As ETCliente) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As DataSet
        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 6)
            db.AddInParameter(cmd, "Anho", DbType.Int32, C.Anho)
            db.AddInParameter(cmd, "Mes", DbType.Int32, C.Mes)
            O = New DataSet
            O = db.ExecuteDataSet(cmd)
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return O
    End Function

    Public Function ConsultaExportacion7(ByVal C As ETCliente) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 7)
            db.AddInParameter(cmd, "Anho", DbType.Int32, C.Anho)
            db.AddInParameter(cmd, "Mes", DbType.Int32, C.Mes)
            db.AddInParameter(cmd, "Semana", DbType.Int32, C.Semana)
            db.AddInParameter(cmd, "Codigo", DbType.String, C.Codigo)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, C.FechaInicio)
            db.AddInParameter(cmd, "FechaFinal", DbType.DateTime, C.FechaFinal)
            O = New ETObjecto
            O.Datos = (db.ExecuteDataSet(cmd)).Tables(0)
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return O
    End Function

    Public Function ConsultaExportacion8() As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 8)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                If O.Respuesta <> 0 Then Err.Raise(10)
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using
        Return O
    End Function

    Public Function ConsultaExportacion9() As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 9)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                If O.Respuesta <> 0 Then Err.Raise(10)
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using
        Return O
    End Function

    Public Function ConsultaExportacion10(ByVal C As ETCliente) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()
            Try
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 10)
                db.AddInParameter(cmd, "FechaGuiaInicio1", DbType.DateTime, C.FechaGuiaInicio1)
                db.AddInParameter(cmd, "FechaGuiaFinal1", DbType.DateTime, C.FechaGuiaFinal1)
                db.AddInParameter(cmd, "FechaGuiaInicio2", DbType.DateTime, C.FechaGuiaInicio2)
                db.AddInParameter(cmd, "FechaGuiaFinal2", DbType.DateTime, C.FechaGuiaFinal2)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                If O.Respuesta <> 0 Then Err.Raise(10)
                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using
        Return O
    End Function

    Public Function ConsultaExportacion11(ByVal C As ETCliente) As ETObjecto
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 11)
            db.AddInParameter(cmd, "Codigo", DbType.String, C.Codigo)
            db.AddInParameter(cmd, "FechaInicio", DbType.DateTime, C.FechaInicio)
            db.AddInParameter(cmd, "FechaFinal", DbType.DateTime, C.FechaFinal)
            O = New ETObjecto
            O.Datos = (db.ExecuteDataSet(cmd)).Tables(0)
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
        Return O
    End Function

    Public Function VerificarProforma(ByVal Rpt As ETProforma) As ETCliente

        Dim lResult As ETCliente = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.VerificarProforma)

        Try

            lResult = New ETCliente

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "NumPedido", DbType.String, Rpt.NumPedido)
            db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

            db.ExecuteNonQuery(cmd)

            lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

            If lResult.Respuesta = 0 Then lResult.Validacion = Boolean.TrueString

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing
        End Try

        Return lResult

    End Function

    Public Function ConsultaProduccionDetallada(ByVal C As ETCliente) As List(Of ETCliente)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultaExportacion)
        Dim O As ETObjecto
        Dim lst As New List(Of ETCliente)
        Dim E As ETCliente = Nothing

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If O.Respuesta <> 0 Then Err.Raise(10)

                cmd.Parameters.Clear()

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
                db.AddInParameter(cmd, "FechaInicio", DbType.Date, C.FechaInicio)
                db.AddInParameter(cmd, "FechaFinal", DbType.Date, C.FechaFinal)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If O.Respuesta <> 0 Then Err.Raise(10)

                cmd.Parameters.Clear()

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 7)
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Anho", DbType.String, C.Anho)
                db.AddInParameter(cmd, "Mes", DbType.String, C.Mes)
                db.AddInParameter(cmd, "Semana", DbType.String, C.Semana)
                db.AddInParameter(cmd, "Codigo", DbType.String, C.Codigo)

                Using dr As IDataReader = db.ExecuteReader(cmd, Trans)
                    While dr.Read
                        E = New ETCliente
                        E.NroPedido = dr.GetString(dr.GetOrdinal("NroPedido"))
                        E.Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        E.FechaRequerida = dr.GetDateTime(dr.GetOrdinal("FechaRequerida"))
                        E.CodCliente = dr.GetString(dr.GetOrdinal("CodCliente"))
                        E.DesCliente = dr.GetString(dr.GetOrdinal("DesCliente"))
                        E.DocExt = dr.GetString(dr.GetOrdinal("DocExt"))
                        E.CantTON = Math.Round(dr.GetDecimal(dr.GetOrdinal("CantTON")), 2)
                        E.Pais = dr.GetString(dr.GetOrdinal("Pais"))
                        lst.Add(E)
                    End While
                    If Not dr Is Nothing Then
                        dr.Close()
                    End If
                End Using

                cmd.Parameters.Clear()

                db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)
                db.ExecuteNonQuery(cmd, Trans)
                O = New ETObjecto
                O.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))

                If O.Respuesta <> 0 Then Err.Raise(10)

            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            Finally
                Trans.Commit()
                Conexion.Close()
            End Try

        End Using

        Return lst

    End Function

End Class
