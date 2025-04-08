Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization

Public Class DACheckList
    Public Function Mantto_CheckList(ByVal EntCL As ETCheckList, ByVal Ls_CheckList As List(Of ETCheckListDetalle)) As Integer
        Dim LResult As ETCheckList = Nothing
        If EntCL Is Nothing Then
            Return Nothing
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_CheckList)
                If Not (EntCL.Tipo = 1) Then
                    db.AddInParameter(cmd, "CheckListID", DbType.Int32, EntCL.CheckList)
                End If

                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodCheckList", DbType.Int32, Val(EntCL.Codigo))
                db.AddInParameter(cmd, "Fecha", DbType.Date, EntCL.Fecha)
                db.AddInParameter(cmd, "Responsable", DbType.String, EntCL.ResponsableID)
                db.AddInParameter(cmd, "TipoCheckList", DbType.Boolean, EntCL.TipoChL)
                db.AddInParameter(cmd, "EquipoID", DbType.Int32, EntCL.EquipoID)
                db.AddInParameter(cmd, "AtributoControl", DbType.Int32, EntCL.AtributoControl)
                db.AddInParameter(cmd, "ValorControl", DbType.String, EntCL.Valor)
                db.AddInParameter(cmd, "status", DbType.String, EntCL.Status)
                db.AddInParameter(cmd, "User", DbType.String, EntCL.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, EntCL.Tipo.ToString)

                LResult = New ETCheckList
                If EntCL.Tipo = 1 Then
                    LResult.CheckList = db.ExecuteScalar(cmd, Trans)
                Else
                    db.ExecuteScalar(cmd, Trans)
                    LResult.CheckList = EntCL.CheckList
                End If

                If Not (EntCL.Tipo = 3) Then
                    For Each Row As ETCheckListDetalle In Ls_CheckList
                        Dim xmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_CheckList_Detalle)
                        db.AddInParameter(xmd, "CheckListID", DbType.Int32, LResult.CheckList)
                        db.AddInParameter(xmd, "EquipoParteEq", DbType.Int32, Row.ParteEqID)
                        db.AddInParameter(xmd, "Urgencia", DbType.String, Row.Urgente)
                        db.AddInParameter(xmd, "UrgenciaMantto", DbType.String, Row.UrgenteMantto)
                        db.AddInParameter(xmd, "Observacion", DbType.String, Row.Observacion)
                        db.AddInParameter(xmd, "status", DbType.String, Row.Status)
                        db.AddInParameter(xmd, "User", DbType.String, Row.Usuario)
                        If Row.Nuevo = Boolean.TrueString Then
                            db.AddInParameter(xmd, "Tipo", DbType.String, "1")
                        Else
                            db.AddInParameter(xmd, "Tipo", DbType.String, "2")
                        End If

                        db.ExecuteNonQuery(xmd, Trans)
                    Next
                End If

                LResult.Respuesta = 1
                LResult.Validacion = Boolean.TrueString
                Trans.Commit()
                Conexion.Close()

            Catch Err As Exception
                LResult.Respuesta = 0
                Trans.Rollback()
                Conexion.Close()

                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
            End Try
        End Using
        Return LResult.Respuesta

    End Function

    Public Function Consultar_CheckList() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_CheckList)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CheckList = New ETCheckList
                    With Entidad.CheckList
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .Responsable = dr.GetString(dr.GetOrdinal("Responsable"))
                        .TipoCL = dr.GetString(dr.GetOrdinal("TipoCL"))
                        .Equipo = dr.GetString(dr.GetOrdinal("Equipo"))
                        .Control = dr.GetString(dr.GetOrdinal("Control"))
                        .Valor = dr.GetString(dr.GetOrdinal("Valor"))
                        .Und = dr.GetString(dr.GetOrdinal("Und"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .TipoChL = dr.GetBoolean(dr.GetOrdinal("TipoChL"))
                        .ResponsableID = dr.GetString(dr.GetOrdinal("ResponsableID"))
                        .EquipoID = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .AtributoControl = dr.GetInt32(dr.GetOrdinal("AtributoID"))
                        .TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                        .Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                        .Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                        .UniMed = dr.GetString(dr.GetOrdinal("UniMed"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .CheckList = dr.GetInt32(dr.GetOrdinal("CheckListID"))
                        lResult.Ls_CheckList.Add(Entidad.CheckList)
                    End With
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function


    Public Function Consultar_DetalleCheckList(ByVal EntCL As ETCheckList) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_CheckList_Detalle)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Interno", DbType.Boolean, EntCL.TipoChL)
            db.AddInParameter(cmd, "Equipo", DbType.Int32, EntCL.EquipoID)
            db.AddInParameter(cmd, "CheckListID", DbType.Int32, EntCL.CheckList)
            db.AddInParameter(cmd, "Tipo", DbType.String, EntCL.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CheckListDet = New ETCheckListDetalle
                    With Entidad.CheckListDet
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .ParteEq = dr.GetString(dr.GetOrdinal("Componente"))
                        .Urgente = dr.GetString(dr.GetOrdinal("Usuario"))
                        .UrgenteMantto = dr.GetString(dr.GetOrdinal("Mantto"))
                        .Observacion = dr.GetString(dr.GetOrdinal("Observacion"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .ParteEqID = dr.GetInt32(dr.GetOrdinal("ComponenteID"))
                        .Nuevo = dr.GetBoolean(dr.GetOrdinal("Nuevo"))
                        lResult.Ls_CheckListDet.Add(Entidad.CheckListDet)

                    End With
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function
    Public Function Consultar_CheckList_Equipo(ByVal Ent_CheckList As ETCheckList) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_CheckList)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "EquipoID", DbType.Int32, Ent_CheckList.EquipoID)
            db.AddInParameter(cmd, "Tipo", DbType.String, Ent_CheckList.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.CheckList = New ETCheckList
                    With Entidad.CheckList
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha"))
                        .TipoCL = dr.GetString(dr.GetOrdinal("TipoCL"))
                        .Control = dr.GetString(dr.GetOrdinal("Control"))
                        .Valor = dr.GetString(dr.GetOrdinal("Valor"))
                        .Und = dr.GetString(dr.GetOrdinal("Und"))
                        .CheckList = dr.GetInt32(dr.GetOrdinal("CheckListID"))
                        lResult.Ls_CheckList.Add(Entidad.CheckList)
                    End With
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = Boolean.TrueString
            End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = Nothing

        End Try

        Return lResult

    End Function
End Class
