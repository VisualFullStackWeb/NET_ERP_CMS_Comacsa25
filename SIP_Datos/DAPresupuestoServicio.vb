Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAPresupuestoServicio
    Public Function Mantenedor_Presup_Servicio(ByVal Ls_Servicio As List(Of ETPresupuestoServicio)) As Integer
        Dim lResult As ETPresupuestoServicio = Nothing
        If Ls_Servicio Is Nothing Then Return 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try

                For Each Ent_Servicio As ETPresupuestoServicio In Ls_Servicio
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Servicio)
                    db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Servicio.Presupuesto)
                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd, "Servicio", DbType.String, Ent_Servicio.Cod_Ser)
                    db.AddInParameter(cmd, "UnidadMedida", DbType.String, Ent_Servicio.Cod_UniMed)
                    db.AddInParameter(cmd, "Cantidad", DbType.Double, Ent_Servicio.Cantidad)
                    db.AddInParameter(cmd, "Precio", DbType.Double, Ent_Servicio.Precio)
                    db.AddInParameter(cmd, "SubTotal", DbType.Double, Ent_Servicio.SubTotal)
                    db.AddInParameter(cmd, "Nro_OC", DbType.String, Ent_Servicio.Nro_OC)
                    db.AddInParameter(cmd, "status", DbType.String, Ent_Servicio.Status)
                    db.AddInParameter(cmd, "User", DbType.String, Ent_Servicio.Usuario)
                    db.AddInParameter(cmd, "Servicio_Ant", DbType.String, Ent_Servicio.Servicio_Ant)
                    db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Servicio.Tipo.ToString)
                    db.ExecuteNonQuery(cmd, Trans)
                Next

                lResult = New ETPresupuestoServicio
                lResult.Respuesta = 1
                Trans.Commit()
                conexion.Close()
                Return lResult.Respuesta

            Catch Err As Exception
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing
            End Try
        End Using
    End Function
    Public Function Consultar_Presup_Servicio(ByVal Ent_Servicio As ETPresupuestoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Ent_Servicio Is Nothing Then Return Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Servicio)
        db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Servicio.PresupuestoDet)
        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Servicio.Tipo.ToString)

        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_Servicio = New ETPresupuestoServicio
                With Entidad.Presupuesto_Servicio
                    .Presupuesto = dr.GetInt32(dr.GetOrdinal("DetallePresupuestoID"))
                    .Cod_Ser = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Servicio = dr.GetString(dr.GetOrdinal("Servicio"))
                    .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                    .Cantidad = dr.GetDecimal(dr.GetOrdinal("CANTIDAD"))
                    .Precio = dr.GetDecimal(dr.GetOrdinal("PRECIO"))
                    .SubTotal = dr.GetDecimal(dr.GetOrdinal("SUBTOTAL"))
                    .Nro_OC = dr.GetString(dr.GetOrdinal("NRO_OC"))
                    .Cod_UniMed = dr.GetString(dr.GetOrdinal("COD_UniMed"))
                    .Tipo = 2
                    If Ent_Servicio.Tipo = 5 Then
                        .Planificado = dr.GetDecimal(dr.GetOrdinal("PLANIFICADO"))
                        .Disponible = dr.GetDecimal(dr.GetOrdinal("DISPONIBLE"))
                        .Entero = dr.GetBoolean(dr.GetOrdinal("Entero"))
                    End If
                End With
                lResult.Ls_Presupuesto_Servicio.Add(Entidad.Presupuesto_Servicio)
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using

        Return lResult
    End Function
    Public Function Consultar_Lista_Servicio() As ETMyLista
        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida_Recursos)

        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, "4")

        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_Servicio = New ETPresupuestoServicio
                With Entidad.Presupuesto_Servicio
                    .Cod_Ser = dr.GetString(dr.GetOrdinal("Cod_Prod"))
                    .Servicio = dr.GetString(dr.GetOrdinal("Producto"))
                    .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                    .Precio = dr.GetDecimal(dr.GetOrdinal("Precio"))
                    .Nro_OC = dr.GetString(dr.GetOrdinal("NRO_OC"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Cod_UniMed = dr.GetString(dr.GetOrdinal("COD_UniMed"))
                End With
                lResult.Ls_Presupuesto_Servicio.Add(Entidad.Presupuesto_Servicio)
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using

        Return lResult
    End Function
End Class
