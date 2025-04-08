Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports SIP_Entidad
Imports System.Globalization
Imports System.Configuration

Public Class DAOrdenTrabajoRecurso
    Public Function Consultar_OrdenTrabajo_Recursos(ByVal Ent_OT As ETOrdenTrabajo_Recursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand

        Select Case Ent_OT.TipoRecurso
            Case "MAT"
                cmd = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo_Material)
            Case "EQ"
                cmd = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo_Equipo)
            Case "MO"
                cmd = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo_ManoObra)
            Case "SER"
                cmd = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo_Servicio)
            Case Else
                cmd = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)
        End Select

        Try
            db.AddInParameter(cmd, "OrdenTrabajo", DbType.Int32, Ent_OT.OrdenTrabajo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)

            If Ent_OT.TipoRecurso = "BL" Then
                db.AddInParameter(cmd, "Tipo", DbType.Int16, 5)
            Else
                db.AddInParameter(cmd, "Tipo", DbType.String, "4")
            End If

            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo_Recursos = New ETOrdenTrabajo_Recursos
                    With Entidad.OrdenTrabajo_Recursos
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad"))
                        .Precio = dr.GetDecimal(dr.GetOrdinal("Precio"))
                        .SubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal"))
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .Recurso = dr.GetString(dr.GetOrdinal("Recurso"))
                        .RecursoID = dr.GetInt32(dr.GetOrdinal("RecursoID"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
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

    Public Function Consultar_OrdenTrabajoOrigen(ByVal Ent_OT As ETOrdenTrabajo_Recursos) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_OrdenTrabajo)

        Try
            db.AddInParameter(cmd, "Equipo", DbType.Int32, Ent_OT.RecursoID)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 6)

            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto
                    With Entidad.OrdenTrabajo
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))

                        .EncargadoArea = dr.GetString(dr.GetOrdinal("EncargadoArea"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Atributo = dr.GetString(dr.GetOrdinal("Atributo"))
                        .ValorControl = dr.GetString(dr.GetOrdinal("ValorControl"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .Cod_EncargadoArea = dr.GetString(dr.GetOrdinal("Cod_EncargadoArea"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .TipoProceso = dr.GetString(dr.GetOrdinal("TipoProceso"))
                        .Cod_Requerimiento = dr.GetInt32(dr.GetOrdinal("Cod_Requerimiento"))
                        .AtributoControl = dr.GetInt32(dr.GetOrdinal("AtributoControl"))
                        .Cod_UniMed = dr.GetString(dr.GetOrdinal("Cod_UniMed"))
                        .TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                        .Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                        .Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                        .AreaInterna = dr.GetString(dr.GetOrdinal("AreaInterna"))
                        .Cod_AreaInt = dr.GetString(dr.GetOrdinal("Cod_AreaInt"))

                    End With
                    lResult.Ls_Orden_Trabajo_Mantto.Add(Entidad.OrdenTrabajo)
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
