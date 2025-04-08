Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DABolsaFactTelefonica

    Public Function Listar(ByVal CodCia As String) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spBolsaTelefonia_Listar)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "CodCia", DbType.String, CodCia)

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
    Public Function Mantenimiento(ByVal pBolsa As ETBolsaFactTelefonica, ByVal pOpcion As Integer) As ETResultado
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spBolsaTelefonia_Mantenimiento)

        Dim trama As String = ""
        Dim Resultado As New ETResultado
        Resultado.Realizo = False

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                db.AddInParameter(cmd, "CodCia", DbType.String, pBolsa.CodCia)
                db.AddInParameter(cmd, "CodBolsa", DbType.String, pBolsa.CodCia)
                db.AddInParameter(cmd, "Bolsa", DbType.String, pBolsa.Bolsa)
                db.AddInParameter(cmd, "Usuario", DbType.String, pBolsa.Usuario)
                db.AddInParameter(cmd, "Operacion", DbType.Int32, pOpcion)

                trama = Convert.ToString(db.ExecuteScalar(cmd, Trans))

                Dim a() As String = trama.Split("|")

                If a(0) = "1" Then
                    Resultado.Realizo = True
                    Resultado.Mensaje = Convert.ToInt32(a(2))
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
End Class
