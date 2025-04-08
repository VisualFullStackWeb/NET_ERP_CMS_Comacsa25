Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Exception

Public Class DAAnexo
    Inherits ETObjecto

#Region "Listar Datos Anexo OC"
    Public Function ListarDatosAnexoOC(ByVal Anexo As ETAnexo) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.ListarAnexoOC_Item)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Anexo.COD_CIA)
            db.AddInParameter(cmd, "Nro_OC", DbType.String, Anexo.NRO_OC)
            db.AddInParameter(cmd, "Item", DbType.String, Anexo.Item_Pedido)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDatosAnexoOC = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

#Region "Listar Datos Anexo Requerimeinto - Ingreso OC"
    Public Function ListarDatosAnexoRequerimiento(ByVal Anexo As ETAnexo) As DataTable
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(usp_RAL.UpdateAnexo_IngresoOC)
        Dim Tabla As DataTable = Nothing
        Dim Ds As DataSet = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Anexo.Cod_Cia)
            db.AddInParameter(cmd, "Nro_Requi", DbType.String, Anexo.Nro_Req)
            db.AddInParameter(cmd, "Item_Requerimiento", DbType.String, Anexo.Item_Requerimiento)
            db.AddInParameter(cmd, "Cod_Producto", DbType.String, Anexo.Codigo_Producto)

            Ds = New DataSet
            Ds = db.ExecuteDataSet(cmd)

            Tabla = New DataTable
            Tabla = Ds.Tables(0).Copy

            ListarDatosAnexoRequerimiento = Tabla

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function
#End Region

End Class
