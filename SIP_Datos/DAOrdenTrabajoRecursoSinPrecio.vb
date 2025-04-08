Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports SIP_Entidad
Imports System.Globalization
Imports System.Configuration
Public Class DAOrdenTrabajoRecursoSinPrecio
    Public Function Mantenedor_OrdenTrabajo_Recurso_Sin_Precio(ByVal ListaPrecioNuevo As List(Of ETOrdenTrabajo_Recursos), _
                                                               ByVal ListaPrecioAntigua As List(Of ETOrdenTrabajo_Recursos)) As ETOrdenTrabajo_Recursos
        Dim lResult As ETOrdenTrabajo_Recursos = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                lResult = New ETOrdenTrabajo_Recursos
                For Each xRow As ETOrdenTrabajo_Recursos In ListaPrecioAntigua
                    If xRow.Action = True Then
                        Dim xmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo_Recurso_SinPrecio)
                        db.AddInParameter(xmd, "OrdenTrabajo", DbType.Int32, xRow.OrdenTrabajo)
                        db.AddInParameter(xmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(xmd, "MatSer", DbType.String, xRow.Codigo)
                        db.AddInParameter(xmd, "CodUnd", DbType.String, xRow.Cod_UniMed)
                        db.AddInParameter(xmd, "Precio", DbType.Double, xRow.Precio)
                        db.AddInParameter(xmd, "Unidad", DbType.String, xRow.UniMed)
                        db.AddInParameter(xmd, "Status", DbType.String, xRow.Status)
                        db.AddInParameter(xmd, "User", DbType.String, xRow.Usuario)
                        db.AddInParameter(xmd, "Tipo", DbType.String, 3)
                        db.ExecuteNonQuery(xmd, Trans)
                    End If
                    
                Next

                For Each xRow As ETOrdenTrabajo_Recursos In ListaPrecioNuevo
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo_Recurso_SinPrecio)
                    db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, xRow.OrdenTrabajo)
                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd, "MatSer", DbType.String, xRow.Codigo)
                    db.AddInParameter(cmd, "CodUnd", DbType.String, xRow.Cod_UniMed)
                    db.AddInParameter(cmd, "Precio", DbType.Double, xRow.Precio)
                    db.AddInParameter(cmd, "Unidad", DbType.String, xRow.UniMed)
                    db.AddInParameter(cmd, "Status", DbType.String, xRow.Status)
                    db.AddInParameter(cmd, "User", DbType.String, xRow.Usuario)
                    db.AddInParameter(cmd, "Tipo", DbType.String, xRow.Tipo.ToString)
                    db.ExecuteNonQuery(cmd, Trans)
                Next

                lResult.Validacion = True
                lResult.Respuesta = 1
                Trans.Commit()
                conexion.Close()
                Return lResult
            Catch Err As Exception
                Trans.Rollback()
                conexion.Close()
                Return Nothing
            End Try
        End Using

    End Function

    Public Function Consultar_OrdenTrabajo_Recurso_SinPrecio(ByVal OrdenTrabajo As ETOrdenTrabajo_Mantto) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo_Recurso_SinPrecio)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, OrdenTrabajo.OrdenTrabajo)
            db.AddInParameter(cmd, "Tipo", DbType.String, OrdenTrabajo.Tipo.ToString)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo_Recursos = New ETOrdenTrabajo_Recursos
                    With Entidad.OrdenTrabajo_Recursos
                        .Recurso = dr.GetString(dr.GetOrdinal("Recurso"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .Precio = dr.GetDecimal(dr.GetOrdinal("Precio"))
                        .UniMed = dr.GetString(dr.GetOrdinal("Unidad"))
                        .OrdenTrabajo = OrdenTrabajo.OrdenTrabajo
                        If OrdenTrabajo.Tipo = 4 Then
                            .Tipo = 2
                            .Moneda = OrdenTrabajo.Moneda
                        Else
                            .Tipo = 1
                            .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        End If

                    End With
                    lResult.Ls_OrdenTrabajo_Recursos.Add(Entidad.OrdenTrabajo_Recursos)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
            Return lResult
        Catch Err As Exception
            Return Nothing
        End Try


    End Function
End Class
