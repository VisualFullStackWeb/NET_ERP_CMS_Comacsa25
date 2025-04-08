Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAConsumoCentroCosto

    Public Function ListarTipoConsumoCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spListarTipoConsumoCentroCosto)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, pConsumoCentroCosto.CodCia)

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

    Public Function ListarUbigeo(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarUbigeo)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "TIPO", DbType.Int32, pConsumoCentroCosto.tipo)
            db.AddInParameter(cmd, "CODDPTO", DbType.String, pConsumoCentroCosto.coddpto)
            db.AddInParameter(cmd, "CODPROV", DbType.String, pConsumoCentroCosto.codprov)

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

    Public Function MantTarifaUbigeo(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.MantTarifaUbigeo)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "OPCION", DbType.Int32, pConsumoCentroCosto.opcion)
            db.AddInParameter(cmd, "ID", DbType.Int32, pConsumoCentroCosto.Id)
            db.AddInParameter(cmd, "COD_UBI_ORI", DbType.String, pConsumoCentroCosto.coddisto)
            db.AddInParameter(cmd, "COD_UBI_DET", DbType.String, pConsumoCentroCosto.coddistd)
            db.AddInParameter(cmd, "PRECIO", DbType.Double, pConsumoCentroCosto.precio)
            db.AddInParameter(cmd, "USUARIO", DbType.String, pConsumoCentroCosto.Usuario)

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

    Public Function ListarTarifaUbigeo(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.ListarTarifaUbigeo)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

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

    Public Function MantenimientoConsumoCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto, ByVal pOp As Integer) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spMantenimientoConsumoCentroCosto)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "Id", DbType.Int32, pConsumoCentroCosto.Id)
            db.AddInParameter(cmd, "CodCia", DbType.String, pConsumoCentroCosto.CodCia)
            db.AddInParameter(cmd, "CodTipo", DbType.String, pConsumoCentroCosto.CodTipo)
            db.AddInParameter(cmd, "CodCentroCosto", DbType.String, pConsumoCentroCosto.CodCentroCosto)
            db.AddInParameter(cmd, "Anio", DbType.Int32, pConsumoCentroCosto.Anio)
            db.AddInParameter(cmd, "Mes", DbType.Int32, pConsumoCentroCosto.Mes)
            db.AddInParameter(cmd, "Consumo", DbType.Decimal, pConsumoCentroCosto.Consumo)
            db.AddInParameter(cmd, "Unidad", DbType.String, pConsumoCentroCosto.Unidad)
            db.AddInParameter(cmd, "Operacion", DbType.Int32, pOp)
            db.AddInParameter(cmd, "User", DbType.String, pConsumoCentroCosto.Usuario)
            db.AddInParameter(cmd, "observacion", DbType.String, pConsumoCentroCosto.Observacion)

            db.AddInParameter(cmd, "TRANSFERENCIA", DbType.String, pConsumoCentroCosto.Transferencia)
            db.AddInParameter(cmd, "COD_EQUIPO", DbType.String, pConsumoCentroCosto.Codequipo)
            db.AddInParameter(cmd, "CENCOS_INI", DbType.String, pConsumoCentroCosto.CodCentroCostoIni)
            db.AddInParameter(cmd, "CENCOS_FIN", DbType.String, pConsumoCentroCosto.CodCentroCostoFin)
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

    Public Function ObtenerConsumoCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spCargarConsumoCentroCosto)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, pConsumoCentroCosto.CodCia)
            db.AddInParameter(cmd, "ID", DbType.String, pConsumoCentroCosto.Id)

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

    Public Function ListarConsumoCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spListarConsumoCentroCosto)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, pConsumoCentroCosto.CodCia)

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

    Public Function ListarCentroCosto(ByVal pConsumoCentroCosto As ETConsumoCentroCosto) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(SP_ADMINISTRACION.spListarCentroCosto)

        Dim dt As DataTable = Nothing
        Dim ds As DataSet = Nothing

        Try

            db.AddInParameter(cmd, "CodCia", DbType.String, pConsumoCentroCosto.CodCia)
            db.AddInParameter(cmd, "CodCenCos", DbType.String, pConsumoCentroCosto.CodCentroCosto)
            db.AddInParameter(cmd, "CodTipo", DbType.String, pConsumoCentroCosto.CodTipo)

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
