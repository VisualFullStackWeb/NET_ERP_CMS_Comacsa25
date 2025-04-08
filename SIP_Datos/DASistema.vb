Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DASistema
    Public Function Mantenedor_Sistemas(ByVal Sistema As ETSistema, ByVal Grupo As List(Of ETSistema)) As Integer
        Dim lResult As Integer = 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Sistema)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "IDSistema", DbType.String, Sistema.ID)
                db.AddInParameter(cmd, "Sistema", DbType.String, Sistema.Sistema)
                db.AddInParameter(cmd, "Abrev", DbType.String, Sistema.Abrev)
                db.AddInParameter(cmd, "User", DbType.String, Sistema.Usuario)
                db.AddInParameter(cmd, "Status", DbType.String, Sistema.Status)
                db.AddInParameter(cmd, "Tipo", DbType.String, Sistema.Tipo.ToString)

                Sistema.ID = db.ExecuteScalar(cmd, Trans).ToString

                For Each xRow As ETSistema In Grupo
                    Dim xmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.EnlaceGrupoSistema)
                    db.AddInParameter(xmd, "Grupo", DbType.String, xRow.ID)
                    db.AddInParameter(xmd, "Sistema", DbType.String, Sistema.ID)
                    db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                    db.AddInParameter(xmd, "Status", DbType.String, xRow.Status)
                    db.AddInParameter(xmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                    db.ExecuteNonQuery(xmd, Trans)
                Next

                lResult = Val(Sistema.ID)
                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                lResult = 0
                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using

        Return lResult

    End Function

    Public Function Consultar_Sistemas() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Sistema)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Sistema = New ETSistema
                    With Entidad.Sistema
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Sistema = dr.GetString(dr.GetOrdinal("Sistema"))
                        .Abrev = dr.GetString(dr.GetOrdinal("Abrev"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        lResult.Ls_Sistema.Add(Entidad.Sistema)
                    End With
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

    Public Function Consultar_SistemaDT() As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Sistema)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")
            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            Consultar_SistemaDT = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        'Dim db As Database = DatabaseFactory.CreateDatabase()
        'Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.Sistema)
        'Dim lResult As DataTable = Nothing

        'Try

        '    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        '    db.AddInParameter(cmd, "Tipo", DbType.String, "4")

        '    lResult = New ETMyLista

        '    Using dr As IDataReader = db.ExecuteReader(cmd)
        '        While dr.Read
        '            Entidad.Sistema = New ETSistema
        '            With Entidad.Sistema
        '                .ID = dr.GetString(dr.GetOrdinal("ID"))
        '                .Sistema = dr.GetString(dr.GetOrdinal("Sistema"))
        '                .Abrev = dr.GetString(dr.GetOrdinal("Abrev"))
        '                .Status = dr.GetString(dr.GetOrdinal("Status"))
        '                lResult.Ls_Sistema.Add(Entidad.Sistema)
        '            End With
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

    Public Function Consultar_Sistemas_Grupos(ByVal System As ETSistema) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(GPA_ERP_COMACSA.EnlaceGrupoSistema)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Sistema", DbType.String, System.ID)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Sistema = New ETSistema
                    With Entidad.Sistema
                        .ID = dr.GetString(dr.GetOrdinal("ID"))
                        .Grupo = dr.GetString(dr.GetOrdinal("Grupo"))
                        .Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                        lResult.Ls_Sistema.Add(Entidad.Sistema)
                    End With
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
