Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient

Public Class DAFamiliaEquipo
    Public Function ManttoFamiliaEquipo(ByVal Entidad As ETFamiliaEquipo) As Integer
        Dim lResult As ETFamiliaEquipo = Nothing
        If Entidad Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_FamiliaEquipo)
                db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int64, Entidad.IDFamiliaEq)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodFamiliaEq", DbType.String, Entidad.Codigo)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Entidad.Descripcion)
                db.AddInParameter(cmd, "status", DbType.String, Entidad.Status)
                db.AddInParameter(cmd, "User", DbType.String, Entidad.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, Entidad.Tipo.ToString)
                lResult = New ETFamiliaEquipo
                lResult.Respuesta = db.ExecuteNonQuery(cmd, Trans)
                

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult.Respuesta


    End Function

    Public Function Mantto_FamiliaEquipo_Image(ByVal Entidad As ETFamiliaEquipo) As Integer
        Dim cn As New SqlConnection
        Dim adapter As New SqlDataAdapter
        Dim lResult As ETFamiliaEquipo = Nothing
        If Entidad Is Nothing Then
            cn = Nothing
            Return 0
        End If

        cn.ConnectionString = ConfigurationManager.ConnectionStrings("cn").ConnectionString
        cn.Open()
        If Entidad.Tipo = 1 Then
            adapter.InsertCommand = New SqlCommand
            adapter.InsertCommand.Connection = cn
            adapter.InsertCommand.CommandText = MPA_Mantenimiento.Mantenimiento_FamiliaEquipo
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure
            adapter.InsertCommand.Parameters.Add("@FamiliaEquipoID", SqlDbType.Int).Value = Entidad.IDFamiliaEq
            adapter.InsertCommand.Parameters.Add("@Cod_Cia", SqlDbType.Char, 2).Value = Companhia
            adapter.InsertCommand.Parameters.Add("@CodFamiliaEq", SqlDbType.Int, Val(Entidad.Codigo))
            adapter.InsertCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = Entidad.Descripcion
            adapter.InsertCommand.Parameters.Add("@Foto", SqlDbType.Image).Value = Entidad.Foto
            adapter.InsertCommand.Parameters.Add("@status", SqlDbType.Char, 1).Value = Entidad.Status
            adapter.InsertCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Usuario
            adapter.InsertCommand.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = 1
            Try
                lResult = New ETFamiliaEquipo
                lResult.Respuesta = adapter.InsertCommand.ExecuteNonQuery()
            Catch Err As Exception
                cn.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            Finally
                cn.Close()
                cn.Dispose()
            End Try
        ElseIf Entidad.Tipo = 2 Then
            adapter.UpdateCommand = New SqlCommand
            adapter.UpdateCommand.Connection = cn
            adapter.UpdateCommand.CommandText = MPA_Mantenimiento.Mantenimiento_FamiliaEquipo
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure
            adapter.UpdateCommand.Parameters.Add("@FamiliaEquipoID", SqlDbType.Int).Value = Entidad.IDFamiliaEq
            adapter.UpdateCommand.Parameters.Add("@Cod_Cia", SqlDbType.Char, 2).Value = Companhia
            adapter.UpdateCommand.Parameters.Add("@CodFamiliaEq", SqlDbType.Int, Val(Entidad.Codigo))
            adapter.UpdateCommand.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = Entidad.Descripcion
            adapter.UpdateCommand.Parameters.Add("@Foto", SqlDbType.Image).Value = Entidad.Foto
            adapter.UpdateCommand.Parameters.Add("@status", SqlDbType.Char, 1).Value = Entidad.Status
            adapter.UpdateCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Usuario
            adapter.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = 1
            Try
                lResult = New ETFamiliaEquipo
                lResult.Respuesta = adapter.UpdateCommand.ExecuteNonQuery()
            Catch Err As Exception
                cn.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            Finally
                cn.Close()
                cn.Dispose()
            End Try
        End If

        Return lResult.Respuesta

    End Function
    Public Function ConsultarFamiliaEq() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_FamiliaEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, EntFamiliaEq.IDCatalogo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.FamiliaEquipo = New ETFamiliaEquipo
                    Entidad.FamiliaEquipo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.FamiliaEquipo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.FamiliaEquipo.Estado = dr.GetString(dr.GetOrdinal("Estado"))

                    Dim byteBLOBData(-1) As [Byte]
                    byteBLOBData = CType(dr.GetValue(dr.GetOrdinal("FOTO")), [Byte]())

                    Entidad.FamiliaEquipo.Foto = byteBLOBData
                    Entidad.FamiliaEquipo.Status = dr.GetString(dr.GetOrdinal("status"))
                    Entidad.FamiliaEquipo.IDFamiliaEq = dr.GetInt32(dr.GetOrdinal("FamiliaEquipoID"))
                    lResult.Ls_FamiliaEquipo.Add(Entidad.FamiliaEquipo)
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
    Public Function ConsultarFamiliaEq_Enlazar() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_FamiliaEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, EntFamiliaEq.IDCatalogo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "5")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.FamiliaEquipo = New ETFamiliaEquipo
                    Entidad.FamiliaEquipo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.FamiliaEquipo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.FamiliaEquipo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_FamiliaEquipo.Add(Entidad.FamiliaEquipo)
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


    Public Function ManttoSubParteEquipo(ByVal Ls_SubParteEq As List(Of ETParteEquipo)) As Integer
        Dim lResult As ETParteEquipo = Nothing
        Dim Grabar As Long
        If Ls_SubParteEq Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Grabar = 0
                For Each Entidad.ParteEquipo In Ls_SubParteEq
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ParteEquipo)
                    With Entidad.ParteEquipo
                        db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, .IDCatalogo)
                        db.AddInParameter(cmd, "CodParteEqOrigen", DbType.Int32, .CompOrigen)
                        db.AddInParameter(cmd, "status", DbType.String, .Status)
                        db.AddInParameter(cmd, "User", DbType.String, .Usuario)
                        db.AddInParameter(cmd, "Tipo", DbType.String, .Tipo.ToString)
                        'lResult = New ETParteEquipo
                        Grabar = Grabar + db.ExecuteNonQuery(cmd, Trans)
                    End With
                Next
                lResult = New ETParteEquipo
                lResult.Respuesta = Grabar

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult.Respuesta


    End Function

    Public Function ConsultarFamiliaEq_Todos() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_FamiliaEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            'db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, EntFamiliaEq.IDCatalogo)
            db.AddInParameter(cmd, "Tipo", DbType.String, "6")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.FamiliaEquipo = New ETFamiliaEquipo
                    Entidad.FamiliaEquipo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.FamiliaEquipo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.FamiliaEquipo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_FamiliaEquipo.Add(Entidad.FamiliaEquipo)
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
End Class
