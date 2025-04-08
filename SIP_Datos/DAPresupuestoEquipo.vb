Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAPresupuestoEquipo
    Public Function Mantenedor_Presup_Equipo(ByVal Ls_Equipo As List(Of ETPresupuestoEquipo)) As Integer
        Dim lResult As ETPresupuestoEquipo = Nothing
        If Ls_Equipo Is Nothing Then Return 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try

                For Each Ent_Equipo As ETPresupuestoEquipo In Ls_Equipo
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Equipo)
                    db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Equipo.Presupuesto)
                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd, "Equipo", DbType.Int32, Ent_Equipo.EquipoID)
                    db.AddInParameter(cmd, "UnidadMedida", DbType.String, Ent_Equipo.Cod_UniMed)
                    db.AddInParameter(cmd, "Cuadrilla", DbType.Int32, Ent_Equipo.Cuadrilla)
                    db.AddInParameter(cmd, "Cantidad", DbType.Double, Ent_Equipo.Cantidad)
                    db.AddInParameter(cmd, "Precio", DbType.Double, Ent_Equipo.Precio)
                    db.AddInParameter(cmd, "SubTotal", DbType.Double, Ent_Equipo.SubTotal)
                    db.AddInParameter(cmd, "status", DbType.String, Ent_Equipo.Status)
                    db.AddInParameter(cmd, "User", DbType.String, Ent_Equipo.Usuario)
                    db.AddInParameter(cmd, "Equipo_Ant", DbType.Int32, Ent_Equipo.Equipo_Ant)
                    db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Equipo.Tipo.ToString)
                    db.ExecuteNonQuery(cmd, Trans)
                Next

                lResult = New ETPresupuestoEquipo
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


    Public Function Consultar_Presup_Equipo(ByVal Ent_Equipo As ETPresupuestoDetalle) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Ent_Equipo Is Nothing Then Return Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Presupuesto_Equipo)
        db.AddInParameter(cmd, "DetallePresupuestoID", DbType.Int32, Ent_Equipo.PresupuestoDet)
        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Equipo.Tipo.ToString)

        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_Equipo = New ETPresupuestoEquipo
                With Entidad.Presupuesto_Equipo
                    .Presupuesto = dr.GetInt32(dr.GetOrdinal("DetallePresupuestoID"))
                    .Cod_Eq = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Equipo = dr.GetString(dr.GetOrdinal("FamiliaEquipo"))
                    .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                    .Cuadrilla = dr.GetInt32(dr.GetOrdinal("Cuadrilla"))
                    .Cantidad = dr.GetDecimal(dr.GetOrdinal("CANTIDAD"))
                    .Precio = dr.GetDecimal(dr.GetOrdinal("PRECIO"))
                    .SubTotal = dr.GetDecimal(dr.GetOrdinal("SUBTOTAL"))
                    .Cod_UniMed = dr.GetString(dr.GetOrdinal("COD_UniMed"))
                    .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                    .Tipo = 2
                    If Ent_Equipo.Tipo = 5 Then
                        .Planificado = dr.GetDecimal(dr.GetOrdinal("PLANIFICADO"))
                        .Disponible = dr.GetDecimal(dr.GetOrdinal("DISPONIBLE"))
                        .Entero = dr.GetBoolean(dr.GetOrdinal("Entero"))
                    End If
                End With
                lResult.Ls_Presupuesto_Equipo.Add(Entidad.Presupuesto_Equipo)

            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using

        Return lResult
    End Function
    Public Function Consultar_Lista_Equipo() As ETMyLista
        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida_Recursos)

        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, "2")

        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Presupuesto_Equipo = New ETPresupuestoEquipo
                With Entidad.Presupuesto_Equipo
                    .Cod_Eq = dr.GetString(dr.GetOrdinal("Cod_Eq"))
                    .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                    .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                    .Precio = dr.GetDecimal(dr.GetOrdinal("Precio"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Cod_UniMed = dr.GetString(dr.GetOrdinal("COD_UniMed"))
                    .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                End With
                lResult.Ls_Presupuesto_Equipo.Add(Entidad.Presupuesto_Equipo)
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using

        Return lResult
    End Function
End Class
