Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DALineaNegocio
    Public Function ManttoLineaNegocio(ByVal Entidad As ETLineaNegocio) As Integer
        Dim lResult As ETLineaNegocio = Nothing
        If Entidad Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_LinNeg)
                db.AddInParameter(cmd, "CodLinNeg", DbType.Int32, Entidad.IDCatalogo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Entidad.Cod_Cia)
                db.AddInParameter(cmd, "Codigo", DbType.String, Entidad.Codigo)
                db.AddInParameter(cmd, "Descripción", DbType.String, Entidad.Descripcion)
                db.AddInParameter(cmd, "status", DbType.String, Entidad.Estado)
                db.AddInParameter(cmd, "User", DbType.String, Entidad.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, Entidad.Tipo.ToString)
                lResult = New ETLineaNegocio
                lResult.Respuesta = db.ExecuteNonQuery(cmd, Trans)
                'If lResult.Respuesta <> 0 Then Err.Raise(10)

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
    Public Function ConsultarLinNeg() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_LinNeg)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.LineaNegocio = New ETLineaNegocio
                    Entidad.LineaNegocio.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.LineaNegocio.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.LineaNegocio.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    Entidad.LineaNegocio.Status = dr.GetString(dr.GetOrdinal("status"))
                    Entidad.LineaNegocio.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_LinNeg.Add(Entidad.LineaNegocio)
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
    Public Function ConsultarLinNeg_Activos() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_LinNeg)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "5")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.LineaNegocio = New ETLineaNegocio
                    Entidad.LineaNegocio.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.LineaNegocio.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.LineaNegocio.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    Entidad.LineaNegocio.Status = dr.GetString(dr.GetOrdinal("status"))
                    Entidad.LineaNegocio.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_LinNeg.Add(Entidad.LineaNegocio)
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
