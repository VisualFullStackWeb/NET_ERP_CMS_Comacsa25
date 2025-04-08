Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAAtributo
    Public Function ManttoAtributo(ByVal Entidad As ETAtributo) As Integer
        Dim lResult As ETAtributo = Nothing
        If Entidad Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try

                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Atributo)
                db.AddInParameter(cmd, "AtributoID", DbType.Int32, Entidad.IDCatalogo)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                db.AddInParameter(cmd, "CodAtributo", DbType.String, Entidad.Codigo)
                db.AddInParameter(cmd, "Descripcion", DbType.String, Entidad.Descripcion)
                db.AddInParameter(cmd, "UnidadMedida", DbType.String, Entidad.UniMed)
                db.AddInParameter(cmd, "TipoDato", DbType.String, Entidad.TipoDato)
                db.AddInParameter(cmd, "Longitud", DbType.Int16, Convert.ToInt16(Entidad.Longitud))
                db.AddInParameter(cmd, "Decimal", DbType.Int16, Convert.ToInt16(Entidad.Decimales))
                db.AddInParameter(cmd, "status", DbType.String, Entidad.Status)
                db.AddInParameter(cmd, "User", DbType.String, Entidad.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, Entidad.Tipo.ToString)
                lResult = New ETAtributo
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
    Public Function ConsultarAtributo() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Atributo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Atributo = New ETAtributo
                    Entidad.Atributo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.Atributo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Atributo.Estado = dr.GetString(dr.GetOrdinal("Estado"))
                    Entidad.Atributo.Status = dr.GetString(dr.GetOrdinal("status"))
                    Entidad.Atributo.UniMed = dr.GetString(dr.GetOrdinal("UnidadMedida"))
                    Entidad.Atributo.TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                    Entidad.Atributo.Longitud = dr.GetString(dr.GetOrdinal("Longitud"))
                    Entidad.Atributo.Decimales = dr.GetString(dr.GetOrdinal("Decimal"))
                    Entidad.Atributo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_Atributo.Add(Entidad.Atributo)
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


    Public Function ExisteAtributo(ByVal Atributo As ETAtributo) As Boolean

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Atributo)
        Dim lResult As Boolean = False
        Try

            db.AddInParameter(cmd, "AtributoID", DbType.Int32, Atributo.IDCatalogo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Descripcion", DbType.String, Atributo.Descripcion.Trim)
            db.AddInParameter(cmd, "Tipo", DbType.String, Atributo.Tipo.ToString)

            lResult = db.ExecuteScalar(cmd)

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            lResult = False

        End Try

        Return lResult

    End Function

    Public Function ManttoAtributoParteEquipo(ByVal Ls_AtributoParteEq As List(Of ETAtributo)) As Integer
        Dim lResult As ETAtributo = Nothing
        Dim Grabar As Long
        Dim Resul As Integer
        If Ls_AtributoParteEq Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Grabar = 0
                For Each Entidad.Atributo In Ls_AtributoParteEq
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_AtributoParteEquipo)
                    With Entidad.Atributo
                        db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, .IDCatalogoOrigen)
                        db.AddInParameter(cmd, "AtributoID", DbType.Int32, .IDCatalogo)
                        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(cmd, "Obligatorio", DbType.Boolean, .Oblig)
                        db.AddInParameter(cmd, "status", DbType.String, .Status)
                        db.AddInParameter(cmd, "User", DbType.String, .Usuario)
                        db.AddInParameter(cmd, "Tipo", DbType.String, .Tipo.ToString)
                        'lResult = New ETParteEquipo
                        Resul = db.ExecuteNonQuery(cmd, Trans)
                        Resul = IIf(Resul < 0, 0, Resul)
                        Grabar = Grabar + Resul
                    End With
                Next
                lResult = New ETAtributo
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

    Public Function ConsultarAtributoParteEq(ByVal EntAtributo As ETAtributo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_AtributoParteEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, EntAtributo.IDCatalogoOrigen)
            db.AddInParameter(cmd, "Tipo", DbType.String, EntAtributo.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Atributo = New ETAtributo
                    If Not (EntAtributo.Tipo = 3) Then
                        Entidad.Atributo.Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                        Entidad.Atributo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        Entidad.Atributo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        Entidad.Atributo.Oblig = dr.GetBoolean(dr.GetOrdinal("Obligatorio"))
                    End If
                    Entidad.Atributo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_Atributo.Add(Entidad.Atributo)
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
    Public Function ManttoAtributoFamiliaEquipo(ByVal Ls_AtributoFamiliaEq As List(Of ETAtributo)) As Integer
        Dim lResult As ETAtributo = Nothing
        Dim Grabar As Long
        Dim Resul As Integer

        If Ls_AtributoFamiliaEq Is Nothing Then
            Return 0
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Grabar = 0
                For Each Entidad.Atributo In Ls_AtributoFamiliaEq
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_AtributoFamiliaEquipo)
                    With Entidad.Atributo
                        db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, .IDCatalogoOrigen)
                        db.AddInParameter(cmd, "AtributoID", DbType.Int32, .IDCatalogo)
                        db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                        db.AddInParameter(cmd, "AtribControlador", DbType.Boolean, .Control)
                        db.AddInParameter(cmd, "Obligatorio", DbType.Boolean, .Oblig)
                        db.AddInParameter(cmd, "AtribCompNomEq", DbType.Boolean, .NomEq)
                        db.AddInParameter(cmd, "Orden", DbType.Int32, .Orden)
                        db.AddInParameter(cmd, "status", DbType.String, .Status)
                        db.AddInParameter(cmd, "User", DbType.String, .Usuario)
                        db.AddInParameter(cmd, "Tipo", DbType.String, .Tipo.ToString)
                        'lResult = New ETParteEquipo
                        Resul = db.ExecuteNonQuery(cmd, Trans)
                        Resul = IIf(Resul < 0, 0, Resul)
                        Grabar = Grabar + Resul
                    End With
                Next
                lResult = New ETAtributo
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

    Public Function ConsultarAtributoFamiliaEq(ByVal EntAtributo As ETAtributo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_AtributoFamiliaEquipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, EntAtributo.IDCatalogoOrigen)
            db.AddInParameter(cmd, "Tipo", DbType.String, EntAtributo.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Atributo = New ETAtributo
                    Entidad.Atributo.Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                    Entidad.Atributo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.Atributo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Atributo.Oblig = dr.GetBoolean(dr.GetOrdinal("Oblig"))
                    Entidad.Atributo.Control = dr.GetBoolean(dr.GetOrdinal("Control"))
                    Entidad.Atributo.NomEq = dr.GetBoolean(dr.GetOrdinal("NomEq"))
                    Entidad.Atributo.Orden = dr.GetInt32(dr.GetOrdinal("Orden"))
                    Entidad.Atributo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    lResult.Ls_Atributo.Add(Entidad.Atributo)
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
