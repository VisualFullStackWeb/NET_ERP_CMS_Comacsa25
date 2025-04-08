Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAGlosa
    Public Function ManttoGlosa(ByVal Entidad As ETGlosa) As Integer
        Dim lResult As ETGlosa = Nothing
        If Entidad Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Glosa)
                db.AddInParameter(cmd, "ID", DbType.Int32, Val(Entidad.ID))
                db.AddInParameter(cmd, "Formulario", DbType.Int32, Entidad.Cod_Modulo)
                db.AddInParameter(cmd, "Glosa", DbType.String, Entidad.Glosa)
                db.AddInParameter(cmd, "Status", DbType.String, Entidad.Status)
                db.AddInParameter(cmd, "User", DbType.String, Entidad.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, Entidad.Tipo.ToString)
                lResult = New ETGlosa
                lResult.ID = db.ExecuteScalar(cmd, Trans)

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

        Return Val(lResult.ID)

    End Function
    Public Function ConsultarGlosa(ByVal Formulario As ETGlosa) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Glosa)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Formulario.ID))
            db.AddInParameter(cmd, "Sistema", DbType.String, Formulario.Cod_Sistema)
            db.AddInParameter(cmd, "Grupo", DbType.String, Formulario.Cod_Grupo)
            db.AddInParameter(cmd, "Formulario", DbType.Int32, Formulario.Cod_Modulo)
            db.AddInParameter(cmd, "Tipo", DbType.String, Formulario.Tipo.ToString)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Glosa = New ETGlosa
                    Entidad.Glosa.ID = dr.GetString(dr.GetOrdinal("ID"))
                    Entidad.Glosa.Cod_Sistema = dr.GetString(dr.GetOrdinal("Cod_Sistema"))
                    Entidad.Glosa.Cod_Grupo = dr.GetString(dr.GetOrdinal("Cod_Grupo"))
                    Entidad.Glosa.Cod_Modulo = dr.GetInt32(dr.GetOrdinal("Cod_Modulo"))
                    Entidad.Glosa.Modulo = dr.GetString(dr.GetOrdinal("Formulario"))
                    Entidad.Glosa.Glosa = dr.GetString(dr.GetOrdinal("Glosa"))
                    Entidad.Glosa.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    Entidad.Glosa.Status = dr.GetString(dr.GetOrdinal("status"))
                    lResult.Ls_Glosa.Add(Entidad.Glosa)
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

    Public Function ConsultarGlosaFormulario(ByVal Formulario As ETGlosa) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Glosa)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Formulario", DbType.Int32, Formulario.Cod_Modulo)
            db.AddInParameter(cmd, "Tipo", DbType.String, Formulario.Tipo.ToString)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Glosa = New ETGlosa
                    Entidad.Glosa.ID = dr.GetInt32(dr.GetOrdinal("ID")).ToString
                    Entidad.Glosa.Glosa = dr.GetString(dr.GetOrdinal("Glosa"))
                    lResult.Ls_Glosa.Add(Entidad.Glosa)
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
    Public Function ValidarAnulacionGlosa(ByVal Formulario As ETGlosa) As Integer

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Glosa)
        Dim lResult As Integer

        Try

            db.AddInParameter(cmd, "ID", DbType.Int32, Val(Formulario.ID))
            db.AddInParameter(cmd, "Tipo", DbType.String, Formulario.Tipo.ToString)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = 0

        End Try

        Return lResult

    End Function
End Class
