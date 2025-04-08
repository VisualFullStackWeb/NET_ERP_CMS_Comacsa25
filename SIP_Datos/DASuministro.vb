Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DASuministro

    Public Function ConsultarSuministro5() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSuministro)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 5)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Suministro = New ETSuministro
                    Entidad.Suministro.CodEmpaque = dr.GetString(dr.GetOrdinal("CodEmpaque"))
                    Entidad.Suministro.DesEmpaque = dr.GetString(dr.GetOrdinal("DesEmpaque"))
                    Entidad.Suministro.Status = dr.GetString(dr.GetOrdinal("Status"))
                    lResult.Ls_Suministro.Add(Entidad.Suministro)
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

    Public Function ConsultarSuministro() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSuministro)
        Dim lResult As ETMyLista = Nothing
        Dim Ds As DataSet = Nothing
        Dim Tabla As DataTable = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Suministro = New ETSuministro
                    Entidad.Suministro.CodEmpaque = dr.GetString(dr.GetOrdinal("CodEmpaque"))
                    Entidad.Suministro.DesEmpaque = dr.GetString(dr.GetOrdinal("DesEmpaque"))
                    Entidad.Suministro.CodSuministro = dr.GetString(dr.GetOrdinal("CodSuministro"))
                    Entidad.Suministro.DesSuministro = dr.GetString(dr.GetOrdinal("DesSuministro"))
                    lResult.Ls_Suministro.Add(Entidad.Suministro)
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

    Public Function ConsultarSuministro2(ByVal Rpt As ETProducto) As DataTable


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSuministro)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing


        Try
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodSuministro", DbType.String, Rpt.CodProducto)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarSuministro2 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            ConsultarSuministro2 = Nothing
        End Try

    End Function

    Public Function ConsultarSuministro3(ByVal Suministro As ETSuministro) As DataTable


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSuministro)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 3)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodEmpaque", DbType.String, Suministro.CodEmpaque)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ConsultarSuministro3 = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            ConsultarSuministro3 = Nothing
        End Try

    End Function

    Public Function ConsultarSuministro4() As ETMyLista


        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarSuministro)

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Suministro = New ETSuministro
                    Entidad.Suministro.CodSuministro = dr.GetString(dr.GetOrdinal("CodSuministro"))
                    Entidad.Suministro.CodAnterior = dr.GetString(dr.GetOrdinal("CodAnterior"))
                    Entidad.Suministro.DesSuministro = dr.GetString(dr.GetOrdinal("DesSuministro"))
                    lResult.Ls_Suministro.Add(Entidad.Suministro)
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

    Public Function MantenimientoEmpaques(ByVal Rpt As ETSuministro, ByVal Ls_Suministro As List(Of ETSuministro)) As ETSuministro

        Dim lResult As ETSuministro = Nothing
        If Rpt Is Nothing OrElse Ls_Suministro Is Nothing Then
            Return lResult
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                lResult = New ETSuministro

                Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoEmpaques)

                db.AddInParameter(cmd, "Tipo", DbType.Int16, Rpt.Tipo)
                db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
                db.AddParameter(cmd, "CodSuministro", DbType.String, 8, ParameterDirection.InputOutput, True, 0, 0, "", DataRowVersion.Default, Rpt.CodSuministro)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Rpt.Descripcion)
                db.AddInParameter(cmd, "Status", DbType.String, Rpt.Status)
                db.AddInParameter(cmd, "Usuario", DbType.String, Rpt.Usuario)
                db.AddOutParameter(cmd, "Respuesta", DbType.Int16, 10)

                db.ExecuteNonQuery(cmd, Trans)

                lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(cmd, "Respuesta"))
                lResult.CodEmpaque = Convert.ToString(db.GetParameterValue(cmd, "CodSuministro"))

                If lResult.Respuesta <> 0 Then Err.Raise(10)

                For Each Row As ETSuministro In Ls_Suministro

                    Dim xmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.MantenimientoEmpaques)

                    db.AddInParameter(xmd, "Tipo", DbType.Int16, 3)
                    db.AddInParameter(xmd, "Companhia", DbType.String, Companhia)
                    db.AddInParameter(xmd, "CodSuministro", DbType.String, lResult.CodEmpaque)
                    db.AddInParameter(xmd, "CodEnlace", DbType.String, Row.CodSuministro)
                    db.AddInParameter(xmd, "CodAnterior", DbType.String, Row.CodAnterior)
                    db.AddInParameter(xmd, "Usuario", DbType.String, Rpt.Usuario)
                    db.AddOutParameter(xmd, "Respuesta", DbType.Int16, 10)

                    db.ExecuteNonQuery(xmd, Trans)
                    lResult.Respuesta = Convert.ToInt16(db.GetParameterValue(xmd, "Respuesta"))
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

    Public Function CuadroxOrdenxSuministro(ByVal P As ETProducto) As List(Of ETSuministro)

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.CuadroxOrdenxSuministro)
        Dim lst As New List(Of ETSuministro)
        Dim E As ETSuministro = Nothing

        Try

            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodProducto", DbType.String, P.CodProducto)
            db.AddInParameter(cmd, "FechaTermino", DbType.Date, P.FechaTerminacion.Date)
            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read

                    E = New ETSuministro

                    E.CodSuministro = dr.GetString(dr.GetOrdinal("CodSuministro"))
                    E.Descripcion = dr.GetString(dr.GetOrdinal("DesSuministro"))
                    E.Peso = dr.GetDecimal(dr.GetOrdinal("Peso"))
                    E.Unidad = dr.GetString(dr.GetOrdinal("UndPeso"))
                    E.UndDesp = dr.GetString(dr.GetOrdinal("UndPesoProducida"))
                    E.CostoUnitario = dr.GetDecimal(dr.GetOrdinal("CostoUnitario"))

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

    Public Function ConsultaConsumoSuministro(ByVal Criterio As ETPedido) As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ReporteConsumoSuministro)
        Dim ds As DataSet

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "FechaInicio", DbType.Date, Criterio.Fecha1)
            db.AddInParameter(cmd, "FechaTermino", DbType.Date, Criterio.Fecha2)
            db.AddInParameter(cmd, "Cod_Alm", DbType.String, Criterio.Codigo_Almacen)
            db.AddInParameter(cmd, "Cod_Empleado", DbType.String, Criterio.Codigo_Empleo)
            db.AddInParameter(cmd, "Cod_Area", DbType.String, Criterio.Codigo_Area)
            db.AddInParameter(cmd, "Tipo", DbType.String, Criterio.Tipo_Doc)

            ds = db.ExecuteDataSet(cmd)

        Catch Err As Exception
            ds = Nothing
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
        End Try

        Return ds
    End Function

End Class
