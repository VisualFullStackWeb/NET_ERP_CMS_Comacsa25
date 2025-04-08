Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAPresupuestoManoObra
    Public Function Mantenedor_Presup_ManoObra(ByVal Ls_ManoObra As List(Of ETPresupuestoManoObra)) As Integer
        Dim lResult As ETPresupuestoManoObra = Nothing
        If Ls_ManoObra Is Nothing Then Return 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try

                For Each Ent_ManoObra As ETPresupuestoManoObra In Ls_ManoObra
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_ManoObra)
                    db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_ManoObra.Presupuesto)
                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd, "Cargo", DbType.String, Ent_ManoObra.Cod_Cargo)
                    db.AddInParameter(cmd, "UnidadMedida", DbType.String, Ent_ManoObra.Cod_UniMed)
                    db.AddInParameter(cmd, "Cuadrilla", DbType.String, Ent_ManoObra.Cuadrilla)
                    db.AddInParameter(cmd, "Cantidad", DbType.Double, Ent_ManoObra.Cantidad)
                    db.AddInParameter(cmd, "Precio", DbType.Double, Ent_ManoObra.Precio)
                    db.AddInParameter(cmd, "SubTotal", DbType.Double, Ent_ManoObra.SubTotal)
                    db.AddInParameter(cmd, "status", DbType.String, Ent_ManoObra.Status)
                    db.AddInParameter(cmd, "User", DbType.String, Ent_ManoObra.Usuario)
                    db.AddInParameter(cmd, "Cargo_Ant", DbType.String, Ent_ManoObra.Cargo_Ant)
                    db.AddInParameter(cmd, "Tipo", DbType.String, Ent_ManoObra.Tipo.ToString)
                    db.ExecuteNonQuery(cmd, Trans)
                Next

                lResult = New ETPresupuestoManoObra
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
    Public Function Consultar_Presup_ManoObra(ByVal Ent_ManoObra As ETPresupuestoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Ent_ManoObra Is Nothing Then Return Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_ManoObra)
        db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_ManoObra.PresupuestoDet)
        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_ManoObra.Tipo.ToString)

        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_ManoObra = New ETPresupuestoManoObra
                With Entidad.Presupuesto_ManoObra
                    .Presupuesto = dr.GetInt32(dr.GetOrdinal("DetallePresupuestoID"))
                    .Cod_Cargo = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Cargo = dr.GetString(dr.GetOrdinal("Cargo"))
                    .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                    .Cuadrilla = dr.GetInt32(dr.GetOrdinal("Cuadrilla"))
                    .Cantidad = dr.GetDecimal(dr.GetOrdinal("CANTIDAD"))
                    .Precio = dr.GetDecimal(dr.GetOrdinal("PRECIO"))
                    .SubTotal = dr.GetDecimal(dr.GetOrdinal("SUBTOTAL"))
                    .Cod_UniMed = dr.GetString(dr.GetOrdinal("COD_UniMed"))
                    .Tipo = 2
                    If Ent_ManoObra.Tipo = 5 Then
                        .Planificado = dr.GetDecimal(dr.GetOrdinal("PLANIFICADO"))
                        .Disponible = dr.GetDecimal(dr.GetOrdinal("DISPONIBLE"))
                        .Entero = dr.GetBoolean(dr.GetOrdinal("Entero"))
                    End If
                End With
                lResult.Ls_Presupuesto_ManoObra.Add(Entidad.Presupuesto_ManoObra)
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using

        Return lResult
    End Function
    Public Function Consultar_Lista_ManoObra() As ETMyLista
        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida_Recursos)

        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, "3")

        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_ManoObra = New ETPresupuestoManoObra
                With Entidad.Presupuesto_ManoObra
                    .Cod_Cargo = dr.GetString(dr.GetOrdinal("Cod_Cargo"))
                    .Cargo = dr.GetString(dr.GetOrdinal("Cargo"))
                    .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                    .Precio = dr.GetDecimal(dr.GetOrdinal("Precio"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Cod_UniMed = dr.GetString(dr.GetOrdinal("COD_UniMed"))
                End With
                lResult.Ls_Presupuesto_ManoObra.Add(Entidad.Presupuesto_ManoObra)
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using

        Return lResult
    End Function
End Class
