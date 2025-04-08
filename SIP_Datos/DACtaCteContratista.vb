Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DACtaCteContratista
    Public Function ConsultarCuentaCorrienteContratista(ByVal Cod_Prov As String, ByVal Anio As Integer) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.CtaCteContratista)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cod_Prov", DbType.String, Cod_Prov)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Anio)


            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CtaCteContratista = New ETCuentaCorriente
                    With Entidad.CtaCteContratista
                        .ID = dr.GetInt32(dr.GetOrdinal("ID"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Documento = dr.GetString(dr.GetOrdinal("Documento"))
                        .Numero = dr.GetString(dr.GetOrdinal("Numero"))
                        .Detalle = dr.GetString(dr.GetOrdinal("Detalle"))
                        .Debe = dr.GetDecimal(dr.GetOrdinal("Debe"))
                        .Haber = dr.GetDecimal(dr.GetOrdinal("Haber"))
                        .Saldo = dr.GetDecimal(dr.GetOrdinal("Saldo"))
                        .Lote = dr.GetString(dr.GetOrdinal("Lote"))
                        .Voucher = dr.GetString(dr.GetOrdinal("Voucher"))
                        .VoucherConta = dr.GetString(dr.GetOrdinal("VoucherConta"))
                    End With
                   
                    lResult.Ls_CtaCteContratista.Add(Entidad.CtaCteContratista)
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
