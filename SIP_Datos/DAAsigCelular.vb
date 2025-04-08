Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient

Public Class DAAsigCelular

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

    Public Function MantenimientoCelularesAsignados(ByVal pAsigCelular As ETAsigCelular, ByVal pOpcion As Integer) As ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigCelular_Mantenimiento)

        Dim trama As String = ""
        Dim Resultado As New ETResultado
        Resultado.Realizo = False

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "CodCia", DbType.String, pAsigCelular.CodCia)
                db.AddInParameter(cmd, "ID", DbType.String, pAsigCelular.ID)
                db.AddInParameter(cmd, "PlaCod", DbType.String, pAsigCelular.PlaCod)
                db.AddInParameter(cmd, "NroCelular", DbType.String, pAsigCelular.NroCelular)
                db.AddInParameter(cmd, "Tarifa", DbType.Decimal, pAsigCelular.Tarifa)
                db.AddInParameter(cmd, "CodGrupo", DbType.String, pAsigCelular.CodBolsa)
                db.AddInParameter(cmd, "Usuario", DbType.String, pAsigCelular.Usuario)
                db.AddInParameter(cmd, "Operacion", DbType.Int32, pOpcion)

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

    Public Function ListarCelularesAsignados(ByVal pAsigCelular As ETAsigCelular) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigCelular_Listar)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "cod_cia", DbType.String, pAsigCelular.CodCia)
            db.AddInParameter(cmd, "placod", DbType.String, pAsigCelular.PlaCod)

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

    Public Function ListarBolsas(ByVal pAsigCelular As ETAsigCelular) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigCelular_ListarBolsas)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, pAsigCelular.CodCia)

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
    Public Function Obtener(ByVal pAsigCelular As ETAsigCelular) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spAsigCelular_Obtener)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "ID", DbType.String, pAsigCelular.ID)

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
End Class
