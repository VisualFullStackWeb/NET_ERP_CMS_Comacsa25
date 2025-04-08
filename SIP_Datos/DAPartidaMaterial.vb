Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports SIP_Entidad
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DAPartidaMaterial
    Public Function Mantenedor_Part_Material(ByVal Ls_Material As List(Of ETPartidaMaterial)) As Integer
        Dim lResult As ETPartidaMaterial = Nothing
        If Ls_Material Is Nothing Then Return 0
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try

                For Each Ent_Material As ETPartidaMaterial In Ls_Material
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida_Material)
                    db.AddInParameter(cmd, "PartidaID", DbType.Int32, Ent_Material.Partida)
                    db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                    db.AddInParameter(cmd, "Material", DbType.String, Ent_Material.Cod_Mat)
                    db.AddInParameter(cmd, "UnidadMedida", DbType.String, Ent_Material.Cod_UniMed)
                    db.AddInParameter(cmd, "Cantidad", DbType.Double, Ent_Material.Cantidad)
                    db.AddInParameter(cmd, "Precio", DbType.Double, Ent_Material.Precio)
                    db.AddInParameter(cmd, "SubTotal", DbType.Double, Ent_Material.SubTotal)
                    db.AddInParameter(cmd, "Nro_OC", DbType.String, Ent_Material.Nro_OC)
                    db.AddInParameter(cmd, "status", DbType.String, Ent_Material.Status)
                    db.AddInParameter(cmd, "User", DbType.String, Ent_Material.Usuario)
                    db.AddInParameter(cmd, "Material_Ant", DbType.String, Ent_Material.Material_Ant)
                    db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Material.Tipo.ToString)
                    db.ExecuteNonQuery(cmd, Trans)
                Next

                lResult = New ETPartidaMaterial
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
    Public Function Consultar_Part_Material(ByVal Ent_Material As ETPartida) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        If Ent_Material Is Nothing Then Return Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida_Material)
        db.AddInParameter(cmd, "PartidaID", DbType.Int32, Ent_Material.Partida)
        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, Ent_Material.Tipo.ToString)

        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Partida_Material = New ETPartidaMaterial
                With Entidad.Partida_Material
                    .Partida = dr.GetInt32(dr.GetOrdinal("PARTIDAID"))
                    .Cod_Mat = dr.GetString(dr.GetOrdinal("Codigo"))
                    .Material = dr.GetString(dr.GetOrdinal("Material"))
                    .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                    .Cantidad = dr.GetDecimal(dr.GetOrdinal("CANTIDAD"))
                    .Precio = dr.GetDecimal(dr.GetOrdinal("PRECIO"))
                    If Ent_Material.Tipo = 5 Then
                        .SubTotal = .Cantidad * .Precio
                    Else
                        .SubTotal = dr.GetDecimal(dr.GetOrdinal("SUBTOTAL"))
                    End If

                    .Nro_OC = dr.GetString(dr.GetOrdinal("NRO_OC"))
                    .Cod_UniMed = dr.GetString(dr.GetOrdinal("COD_UniMed"))
                    .Tipo = 2
                End With
                lResult.Ls_Partida_Material.Add(Entidad.Partida_Material)
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using

        Return lResult
    End Function
    Public Function Consultar_Lista_Material() As ETMyLista
        Dim lResult As ETMyLista = Nothing

        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida_Recursos)

        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
        db.AddInParameter(cmd, "Tipo", DbType.String, "1")

        Using dr As IDataReader = db.ExecuteReader(cmd)
            lResult = New ETMyLista
            While dr.Read
                Entidad.Partida_Material = New ETPartidaMaterial
                With Entidad.Partida_Material
                    .Cod_Mat = dr.GetString(dr.GetOrdinal("Cod_Prod"))
                    .Material = dr.GetString(dr.GetOrdinal("Producto"))
                    .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                    .Precio = dr.GetDecimal(dr.GetOrdinal("Precio"))
                    .Nro_OC = dr.GetString(dr.GetOrdinal("NRO_OC"))
                    .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                    .Cod_UniMed = dr.GetString(dr.GetOrdinal("COD_UniMed"))
                End With
                lResult.Ls_Partida_Material.Add(Entidad.Partida_Material)
            End While
            If dr IsNot Nothing Then dr.Close()
            lResult.Validacion = Boolean.TrueString
        End Using

        Return lResult
    End Function
End Class
