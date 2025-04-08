Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAInsumosFProductos

    Public Function Insertar_InsumosFProductos(ByVal db As Database, ByVal Trans As DbTransaction, ByVal C As ETInsumosFProductos) As Integer
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFProductos.Insertar_InsumosFProductos)
        Dim RPTA As Integer = 0
        Try

            db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, C.Id_Prod)
            db.AddInParameter(cmd, "@Cod_Prod", DbType.String, C.Cod_Prod)
            db.AddInParameter(cmd, "@User_Crea", DbType.String, C.User_Crea)

            RPTA = db.ExecuteNonQuery(cmd, Trans)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try
        Return RPTA
    End Function

    Public Function Insertar_InsumosFProductos(ByVal C As ETInsumosFProductos) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFProductos.Insertar_InsumosFProductos)

        Dim RPTA As Integer = 0
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, C.Id_Prod)
                db.AddInParameter(cmd, "@Cod_Prod", DbType.String, C.Cod_Prod)
                db.AddInParameter(cmd, "@User_Crea", DbType.String, C.User_Crea)

                RPTA = db.ExecuteNonQuery(cmd)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
        Return RPTA
    End Function

    Public Function Listar_Productos(ByVal pCod_Cia As String) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFProductos.Listar_Productos)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@Cod_Cia", DbType.String, pCod_Cia)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Function Listar_InsumosFProductosXId_Prod(ByVal pId_Prod As Integer) As DataTable

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFProductos.Listar_InsumosFProductosXId_Prod)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, pId_Prod)

            Return db.ExecuteDataSet(cmd).Tables(0)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try

    End Function

    Public Sub Grabar_ListInsumosFProductos(ByVal ListETInsumosFProductos As List(Of ETInsumosFProductos))

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                If Mostrar_CantidadInsumosFProductosXId_Prod(db, Trans, ListETInsumosFProductos.Item(0).Id_Prod.ToString.Trim) > 0 Then
                    If Anular_InsumosFProductosXId_Prod(db, Trans, ListETInsumosFProductos.Item(0)) <= 0 Then Throw New Exception("Error al Actualizar los Datos: Anular_InsumosFProductosXId_Prod")
                End If

                For Each Et As ETInsumosFProductos In ListETInsumosFProductos
                    If Insertar_InsumosFProductos(db, Trans, Et) <= 0 Then Throw New Exception("Error al Actualizar los Datos: Insertar_InsumosFProductos")
                Next

                Trans.Commit()
                Conexion.Close()
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                Throw New Exception(Err.Message)
            End Try

        End Using

    End Sub

    Public Function Anular_InsumosFProductosXId_Prod(ByVal db As Database, ByVal Trans As DbTransaction, ByVal C As ETInsumosFProductos) As Integer
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFProductos.Anular_InsumosFProductosXId_Prod)
        Dim RPTA As Integer = 0
        Try

            db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, C.Id_Prod)
            db.AddInParameter(cmd, "@User_Modi", DbType.String, C.User_Modi)

            RPTA = db.ExecuteNonQuery(cmd, Trans)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try
        Return RPTA
    End Function

    Public Function Mostrar_CantidadInsumosFProductosXId_Prod(ByVal db As Database, ByVal Trans As DbTransaction, ByVal pId_Prod As Integer) As Integer
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFProductos.Mostrar_CantidadInsumosFProductosXId_Prod)
        Dim RPTA As Integer = 0
        Try

            db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, pId_Prod)

            RPTA = db.ExecuteScalar(cmd, Trans)

        Catch Err As Exception
            Throw New Exception(Err.Message)
            Return Nothing
        End Try
        Return RPTA
    End Function

    Public Function Mostrar_CantidadInsumosFProductosXId_ProdAndCod_Prod(ByVal pId_Prod As Integer, ByVal pCod_Prod As String) As Integer
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_InsumosFProductos.Mostrar_CantidadInsumosFProductosXId_ProdAndCod_Prod)

        Dim RPTA As Integer
        Using Conexion As DbConnection = db.CreateConnection()
            Conexion.Open()
            Try

                db.AddInParameter(cmd, "@Id_Prod", DbType.Int16, pId_Prod)
                db.AddInParameter(cmd, "@Cod_Prod", DbType.String, pCod_Prod)

                RPTA = db.ExecuteScalar(cmd)
                Conexion.Close()
            Catch Err As Exception
                Conexion.Close()
                Throw New Exception(Err.Message)
                Return Nothing
            End Try
        End Using
        Return RPTA
    End Function

End Class
