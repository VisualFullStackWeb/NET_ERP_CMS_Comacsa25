Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAConsultaRRHH
    Public Function ConsultarCuentaCorrientePersonal(ByVal Cod_Emp As String, ByVal Anio As Integer) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(RPA_RecursosHumanos.CtaCorrientePersonal)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Emp", DbType.String, Cod_Emp)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Anio)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CtaCteContratista = New ETCuentaCorriente
                    With Entidad.CtaCteContratista
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Detalle = dr.GetString(dr.GetOrdinal("Detalle"))
                        .Debe = dr.GetDecimal(dr.GetOrdinal("Debe"))
                        .Haber = dr.GetDecimal(dr.GetOrdinal("Haber"))
                        .Saldo = dr.GetDecimal(dr.GetOrdinal("Saldo"))
                        .Voucher = dr.GetString(dr.GetOrdinal("Voucher"))
                        .VoucherConta = dr.GetString(dr.GetOrdinal("VoucherConta"))
                    End With

                    lResult.Ls_CtaCtePersonal.Add(Entidad.CtaCteContratista)
                    Entidad.CtaCteContratista = Nothing
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
