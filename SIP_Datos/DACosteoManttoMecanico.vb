Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient
Public Class DACosteoManttoMecanico
    Public Function Mantenedor_Costeo_ManttoMecanico(ByVal Periodo As ETCosteoManttoMecanico, _
                                             ByVal ListaDetalle As List(Of ETCosteoManttoMecanicoDetalle), _
                                             ByVal ListaAnula As List(Of ETCosteoManttoMecanicoDetalle)) As Integer

        Dim lResult As Long = 0
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Costeo_ManttoMecanico)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
                db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
                db.AddInParameter(cmd, "Horas", DbType.Double, Periodo.Horas)
                db.AddInParameter(cmd, "CostosManoObra", DbType.Double, Periodo.CostoManoObra)
                db.AddInParameter(cmd, "CostosMateriales", DbType.Double, Periodo.CostoMateriales)
                db.AddInParameter(cmd, "Total", DbType.Double, Periodo.Total)
                db.AddInParameter(cmd, "User", DbType.String, Periodo.Usuario)
                db.AddInParameter(cmd, "Status", DbType.String, Periodo.Status)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Periodo.Tipo)

                db.ExecuteNonQuery(cmd, Trans)

                If ListaAnula IsNot Nothing Then
                    For Each xRow As ETCosteoManttoMecanicoDetalle In ListaAnula
                        Dim dxmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Costeo_ManttoMecanicoDetalle)
                        db.AddInParameter(dxmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(dxmd, "Anio", DbType.Int32, Periodo.Anio)
                        db.AddInParameter(dxmd, "Mes", DbType.Int16, Periodo.Mes)
                        db.AddInParameter(dxmd, "Activo", DbType.String, xRow.Codigo)
                        db.AddInParameter(dxmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(dxmd, "Status", DbType.String, xRow.Status)
                        db.AddInParameter(dxmd, "Tipo", DbType.Int16, xRow.Tipo)
                        db.ExecuteNonQuery(dxmd, Trans)
                    Next
                End If
                
                If ListaDetalle IsNot Nothing Then
                    For Each xRow As ETCosteoManttoMecanicoDetalle In ListaDetalle
                        Dim xmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Costeo_ManttoMecanicoDetalle)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "Anio", DbType.Int32, Periodo.Anio)
                        db.AddInParameter(xmd, "Mes", DbType.Int16, Periodo.Mes)
                        db.AddInParameter(xmd, "Activo", DbType.String, xRow.Codigo)
                        db.AddInParameter(xmd, "Horas", DbType.Double, xRow.Horas)
                        db.AddInParameter(xmd, "CostoManoObra", DbType.Double, xRow.CostoManoObra)
                        db.AddInParameter(xmd, "CostoMateriales", DbType.Double, xRow.CostoMateriales)
                        db.AddInParameter(xmd, "Parcial", DbType.Double, xRow.SubTotal)
                        db.AddInParameter(xmd, "Porcentaje", DbType.Double, xRow.Porcentaje)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Status", DbType.String, xRow.Status)
                        db.AddInParameter(xmd, "Tipo", DbType.Int16, xRow.Tipo)
                        db.ExecuteNonQuery(xmd, Trans)
                    Next
                End If

                Trans.Commit()
                Conexion.Close()
                lResult = 1
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = 0
                MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using
        Return lResult

    End Function
    Public Function Consultar_Costeo_ManttoMecanicoDetalle(ByVal Periodo As ETCosteoManttoMecanico) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Costeo_ManttoMecanicoDetalle)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.CosteoManttoMecanicoDetalle = New ETCosteoManttoMecanicoDetalle
                    With Entidad.CosteoManttoMecanicoDetalle
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Horas = dr.GetDecimal(dr.GetOrdinal("horas"))
                        .CostoManoObra = dr.GetDecimal(dr.GetOrdinal("CostoManoObra"))
                        .CostoMateriales = dr.GetDecimal(dr.GetOrdinal("CostoMateriales"))
                        .SubTotal = dr.GetDecimal(dr.GetOrdinal("Parcial"))
                        .Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje"))
                        .Tipo = 2
                    End With
                    lResult.Ls_CosteoManttoMecanicoDetalle.Add(Entidad.CosteoManttoMecanicoDetalle)
                End While

                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using

        Catch Err As Exception

            lResult = Nothing
            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)

        End Try

        Return lResult
    End Function

    Public Function Consultar_Costeo_ManttoMecanico() As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Costeo_ManttoMecanico)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.CosteoManttoMecanico = New ETCosteoManttoMecanico
                    With Entidad.CosteoManttoMecanico
                        .Anio = dr.GetInt32(dr.GetOrdinal("Anio"))
                        .MesName = dr.GetString(dr.GetOrdinal("MesName"))
                        .Mes = dr.GetInt16(dr.GetOrdinal("Mes"))
                        .Horas = dr.GetDecimal(dr.GetOrdinal("horas"))
                        .CostoManoObra = dr.GetDecimal(dr.GetOrdinal("CostosManoObra"))
                        .CostoMateriales = dr.GetDecimal(dr.GetOrdinal("CostosMateriales"))
                        .Total = dr.GetDecimal(dr.GetOrdinal("Total"))
                    End With
                    lResult.Ls_CosteoManttoMecanico.Add(Entidad.CosteoManttoMecanico)
                End While

                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using

        Catch Err As Exception

            lResult = Nothing
            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)

        End Try

        Return lResult
    End Function

    Public Function Validar_Costeo_ManttoMecanico(ByVal Periodo As ETCosteoManttoMecanico) As Boolean
        Dim lResult As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Costeo_ManttoMecanico)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Anio", DbType.Int32, Periodo.Anio)
            db.AddInParameter(cmd, "Mes", DbType.Int16, Periodo.Mes)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 5)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)

        End Try

        Return lResult
    End Function
End Class
