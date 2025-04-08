Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAParteEquipo
    Public Function ManttoParteEquipo(ByVal Entidad As ETParteEquipo) As Integer
        Dim lResult As ETParteEquipo = Nothing
        If Entidad Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ParteEquipo)
                db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, Entidad.IDCatalogo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodParteEq", DbType.String, Entidad.Codigo)
                db.AddInParameter(cmd, "CodParteEqOrigen", DbType.Int32, Entidad.CompOrigen)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Entidad.Descripcion)
                db.AddInParameter(cmd, "status", DbType.String, Entidad.Status)
                db.AddInParameter(cmd, "User", DbType.String, Entidad.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, Entidad.Tipo.ToString)
                lResult = New ETParteEquipo
                lResult.Respuesta = db.ExecuteNonQuery(cmd, Trans)
                'If lResult.Respuesta <> 0 Then Err.Raise(10)

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult.Respuesta


    End Function
    Public Function ConsultarParteEq(ByVal EntParteEq As ETParteEquipo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ParteEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, EntParteEq.IDCatalogo)
            db.AddInParameter(cmd, "Tipo", DbType.String, EntParteEq.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.ParteEquipo = New ETParteEquipo
                    Entidad.ParteEquipo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.ParteEquipo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.ParteEquipo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    Select Case EntParteEq.Tipo
                        Case 4
                            Entidad.ParteEquipo.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                            Entidad.ParteEquipo.Status = dr.GetString(dr.GetOrdinal("status"))
                            ' Entidad.ParteEquipo.CodCompOrigen = dr.GetString(dr.GetOrdinal("CodigoOrigen"))
                            ' Entidad.ParteEquipo.Componente = dr.GetString(dr.GetOrdinal("DescripOrigen"))
                            ' Entidad.ParteEquipo.CompOrigen = dr.GetInt32(dr.GetOrdinal("CompOrigen"))
                            lResult.Ls_ParteEquipo.Add(Entidad.ParteEquipo)
                        Case 5
                            Entidad.ParteEquipo.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                            lResult.Ls_SubParteEquipo.Add(Entidad.ParteEquipo)
                        Case 7
                            Entidad.ParteEquipo.Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                            lResult.Ls_SubParteEquipo.Add(Entidad.ParteEquipo)
                        Case Else
                            lResult.Ls_ParteEquipo.Add(Entidad.ParteEquipo)
                    End Select




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

    Public Function ManttoSubParteEquipo(ByVal Ls_SubParteEq As List(Of ETParteEquipo)) As Integer
        Dim lResult As ETParteEquipo = Nothing
        Dim Grabar As Long
        Dim Resul As Integer

        If Ls_SubParteEq Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Grabar = 0
                For Each Entidad.ParteEquipo In Ls_SubParteEq
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ParteEquipo)
                    With Entidad.ParteEquipo
                        db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, .IDCatalogo)
                        db.AddInParameter(cmd, "CodParteEqOrigen", DbType.Int32, .CompOrigen)
                        db.AddInParameter(cmd, "status", DbType.String, .Status)
                        db.AddInParameter(cmd, "User", DbType.String, .Usuario)
                        db.AddInParameter(cmd, "Tipo", DbType.String, .Tipo.ToString)
                        'lResult = New ETParteEquipo
                        Resul = db.ExecuteNonQuery(cmd, Trans)
                        Resul = IIf(Resul < 0, 0, Resul)
                        Grabar = Grabar + Resul
                    End With
                Next
                lResult = New ETParteEquipo
                lResult.Respuesta = Grabar

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult.Respuesta
    End Function

    Public Function Validar_Circularidad_Comp_SubComp(ByVal SubComponente As ETParteEquipo) As Boolean

        Dim Resul As Boolean = False

        If SubComponente Is Nothing Then
            Return False
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ParteEquipo)

        With SubComponente
            db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, .IDCatalogo)
            db.AddInParameter(cmd, "CodParteEqOrigen", DbType.Int32, .CompOrigen)
            db.AddInParameter(cmd, "Tipo", DbType.String, "9")
        End With
        Resul = db.ExecuteScalar(cmd)
        Return Resul
    End Function

    Public Function Consultar_FamiliaParteEq(ByVal EntParteEq As ETParteEquipo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ComponenteFamiliaEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, EntParteEq.IDCatalogoOrigen)
            db.AddInParameter(cmd, "Tipo", DbType.String, EntParteEq.Tipo.ToString)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.ParteEquipo = New ETParteEquipo
                    Entidad.ParteEquipo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.ParteEquipo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.ParteEquipo.Interno = dr.GetBoolean(dr.GetOrdinal("Interno"))
                    Entidad.ParteEquipo.Item = dr.GetInt32(dr.GetOrdinal("Item"))

                    Select Case EntParteEq.Tipo
                        Case 2
                            Entidad.ParteEquipo.Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                            Entidad.ParteEquipo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                            Entidad.ParteEquipo.IDCatalogoOrigen = EntParteEq.IDCatalogoOrigen
                            Entidad.ParteEquipo.Status = ""
                        Case 3
                            Entidad.ParteEquipo.CodigoOrigen = dr.GetString(dr.GetOrdinal("CodigoOrigen"))
                            Entidad.ParteEquipo.DescripcionOrigen = dr.GetString(dr.GetOrdinal("DescripcionOrigen"))
                    End Select
                    lResult.Ls_ParteEquipo.Add(Entidad.ParteEquipo)
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
    Public Function Mantto_FamiliaEq_ParteEquipo(ByVal Ls_FamiliaEq_ParteEq As List(Of ETParteEquipo)) As Integer
        Dim lResult As ETParteEquipo = Nothing
        Dim Grabar As Long
        Dim Resul As Integer

        If Ls_FamiliaEq_ParteEq Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Grabar = 0
                For Each Entidad.ParteEquipo In Ls_FamiliaEq_ParteEq
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_ComponenteFamiliaEquipo)
                    With Entidad.ParteEquipo
                        db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, .IDCatalogoOrigen)
                        db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, .IDCatalogo)
                        db.AddInParameter(cmd, "Item", DbType.Int16, .Item)
                        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(cmd, "Ubicacion", DbType.Boolean, .Interno)
                        db.AddInParameter(cmd, "status", DbType.String, .Status)
                        db.AddInParameter(cmd, "User", DbType.String, .Usuario)
                        db.AddInParameter(cmd, "Tipo", DbType.String, .Tipo.ToString)
                        'lResult = New ETParteEquipo
                        Resul = db.ExecuteNonQuery(cmd, Trans)
                        Resul = IIf(Resul < 0, 0, Resul)
                        Grabar = Grabar + Resul
                    End With
                Next
                lResult = New ETParteEquipo
                lResult.Respuesta = Grabar

            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return Nothing

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using

        Return lResult.Respuesta
    End Function
End Class
