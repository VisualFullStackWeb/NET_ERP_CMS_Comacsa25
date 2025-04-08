Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Imports System.Data.SqlClient

Public Class DAEquipo

    Private Sub Mantto_EquipoAtributo(ByVal Equipo As Long, ByVal Conexion As SqlConnection, ByVal Trans As SqlTransaction, ByVal Ls_Atributo As List(Of ETAtributo))
        Dim adapter As New SqlDataAdapter
        If Ls_Atributo Is Nothing Then
            Exit Sub
        End If

        For Each Entidad.Atributo In Ls_Atributo
            If Entidad.Atributo.TipoG = Boolean.FalseString Then
                adapter.InsertCommand = New SqlCommand
                adapter.InsertCommand.Connection = Conexion
                adapter.InsertCommand.CommandText = MPA_Mantenimiento.Mantenimiento_EquipoAtributo
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure
                adapter.InsertCommand.Transaction = Trans
                adapter.InsertCommand.Parameters.Add("@EquipoID", SqlDbType.Int).Value = Equipo
                adapter.InsertCommand.Parameters.Add("@FamiliaEquipoID", SqlDbType.Int).Value = Entidad.Atributo.IDCatalogoOrigen
                adapter.InsertCommand.Parameters.Add("@AtributoID", SqlDbType.Int).Value = Entidad.Atributo.IDCatalogo
                adapter.InsertCommand.Parameters.Add("@Valor", SqlDbType.VarChar, 255).Value = Entidad.Atributo.Valor
                adapter.InsertCommand.Parameters.Add("@Status", SqlDbType.Char, 1).Value = Entidad.Atributo.Status
                adapter.InsertCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Atributo.Usuario
                adapter.InsertCommand.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = 1
                adapter.InsertCommand.ExecuteNonQuery()
            Else
                adapter.UpdateCommand = New SqlCommand
                adapter.UpdateCommand.Connection = Conexion
                adapter.UpdateCommand.CommandText = MPA_Mantenimiento.Mantenimiento_EquipoAtributo
                adapter.UpdateCommand.CommandType = CommandType.StoredProcedure
                adapter.UpdateCommand.Transaction = Trans
                adapter.UpdateCommand.Parameters.Add("@EquipoID", SqlDbType.Int).Value = Equipo
                adapter.UpdateCommand.Parameters.Add("@FamiliaEquipoID", SqlDbType.Int).Value = Entidad.Atributo.IDCatalogoOrigen
                adapter.UpdateCommand.Parameters.Add("@AtributoID", SqlDbType.Int).Value = Entidad.Atributo.IDCatalogo
                adapter.UpdateCommand.Parameters.Add("@Valor", SqlDbType.VarChar, 255).Value = Entidad.Atributo.Valor
                adapter.UpdateCommand.Parameters.Add("@Status", SqlDbType.Char, 1).Value = Entidad.Atributo.Status
                adapter.UpdateCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Atributo.Usuario
                adapter.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = 2
                adapter.UpdateCommand.ExecuteNonQuery()
            End If
        Next

    End Sub
    Private Sub Mantto_Equipo_ParteEq_Atrib_Valor(ByVal Conexion As SqlConnection, ByVal Trans As SqlTransaction, ByVal Ls_Atributo As List(Of ETAtributo))
        Dim adapter As New SqlDataAdapter
        If Ls_Atributo Is Nothing Then
            Exit Sub
        End If

        For Each Entidad.Atributo In Ls_Atributo
            If Entidad.Atributo.Tipo = 1 Then
                adapter.InsertCommand = New SqlCommand
                adapter.InsertCommand.Connection = Conexion
                adapter.InsertCommand.CommandText = MPA_Mantenimiento.Mantenimiento_Equipo_ParteEq_Atrib_Valor
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure
                adapter.InsertCommand.Transaction = Trans
                adapter.InsertCommand.Parameters.Add("@EquipoParteEq", SqlDbType.Int).Value = Entidad.Atributo.IDCatalogoOrigen
                adapter.InsertCommand.Parameters.Add("@AtributoID", SqlDbType.Int).Value = Entidad.Atributo.IDCatalogo
                adapter.InsertCommand.Parameters.Add("@Valor", SqlDbType.VarChar, 255).Value = Entidad.Atributo.Valor
                adapter.InsertCommand.Parameters.Add("@Status", SqlDbType.Char, 1).Value = Entidad.Atributo.Status
                adapter.InsertCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Atributo.Usuario
                adapter.InsertCommand.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = 1
                adapter.InsertCommand.ExecuteNonQuery()
            Else
                adapter.UpdateCommand = New SqlCommand
                adapter.UpdateCommand.Connection = Conexion
                adapter.UpdateCommand.CommandText = MPA_Mantenimiento.Mantenimiento_Equipo_ParteEq_Atrib_Valor
                adapter.UpdateCommand.CommandType = CommandType.StoredProcedure
                adapter.UpdateCommand.Transaction = Trans
                adapter.UpdateCommand.Parameters.Add("@EquipoParteEq", SqlDbType.Int).Value = Entidad.Atributo.IDCatalogoOrigen
                adapter.UpdateCommand.Parameters.Add("@AtributoID", SqlDbType.Int).Value = Entidad.Atributo.IDCatalogo
                adapter.UpdateCommand.Parameters.Add("@Valor", SqlDbType.VarChar, 255).Value = Entidad.Atributo.Valor
                adapter.UpdateCommand.Parameters.Add("@Status", SqlDbType.Char, 1).Value = Entidad.Atributo.Status
                adapter.UpdateCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Atributo.Usuario
                adapter.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.Char, 1).Value = 2
                adapter.UpdateCommand.ExecuteNonQuery()
            End If
        Next

    End Sub
    Public Function Mantto_Equipo_ParteEq(ByVal EntEq As ETEquipo, ByVal EntAtributo As ETAtributo) As Long
        Dim lResult As ETAtributo = Nothing
        If EntAtributo Is Nothing Then
            Return 0
            Exit Function
        End If

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Using Conexion As DbConnection = db.CreateConnection()

            Conexion.Open()

            Dim Trans As DbTransaction = Conexion.BeginTransaction()

            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo_ParteEq)
                If EntAtributo.Tipo = 2 Then
                    db.AddInParameter(cmd, "EquipoParteEq", DbType.Int64, EntAtributo.Nodo)
                End If
                db.AddInParameter(cmd, "EquipoID", DbType.Int64, EntEq.Equipo)
                db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, EntEq.FamiliaEqID)
                db.AddInParameter(cmd, "ParteEquipoRaiz", DbType.Int32, EntAtributo.ParteEquipoRaiz)
                db.AddInParameter(cmd, "ItemRaiz", DbType.Int32, Val(EntAtributo.ItemRaiz))

                If EntAtributo.Level > 0 Then
                    db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, EntAtributo.ParteEquipo)
                    db.AddInParameter(cmd, "Item", DbType.Int32, Val(EntAtributo.ItemPadreParteEq))
                    db.AddInParameter(cmd, "EquipoComp_Padre", DbType.Int64, EntAtributo.NodoPadre)
                    db.AddInParameter(cmd, "SubParteEqID", DbType.Int32, EntAtributo.IDCatalogoOrigen)
                    db.AddInParameter(cmd, "ItemSPE", DbType.Int32, EntAtributo.ItemParteEq)
                End If
                db.AddInParameter(cmd, "Status", DbType.String, EntAtributo.Status)
                db.AddInParameter(cmd, "User", DbType.String, EntAtributo.Usuario)
                db.AddInParameter(cmd, "Tipo", DbType.String, EntAtributo.Tipo.ToString)
                lResult = New ETAtributo
                lResult.Nodo = db.ExecuteScalar(cmd, Trans)
            Catch Err As Exception

                Trans.Rollback()
                Conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return 0

            Finally

                Trans.Commit()
                Conexion.Close()

            End Try

        End Using
        Return lResult.Nodo
    End Function
    Public Function Mantto_Equipo_Image(ByVal Entidad As ETEquipo, ByVal Ls_Atributo As List(Of ETAtributo), ByVal Ls_AtributoParteEq As List(Of ETAtributo)) As Long
        Dim cn As New SqlConnection
        Dim adapter As New SqlDataAdapter
        Dim lResult As ETEquipo = Nothing

        If Entidad Is Nothing Then
            cn = Nothing
            Return 0
        End If

        cn.ConnectionString = ConfigurationManager.ConnectionStrings("cn").ConnectionString
        cn.Open()

        Dim Trans As SqlTransaction = cn.BeginTransaction

        If Entidad.Tipo = 1 Then
            adapter.InsertCommand = New SqlCommand
            adapter.InsertCommand.Connection = cn
            adapter.InsertCommand.CommandText = MPA_Mantenimiento.Mantenimiento_Equipo
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure
            adapter.InsertCommand.Transaction = Trans
            adapter.InsertCommand.Parameters.Add("@EquipoID", SqlDbType.Int).Value = Entidad.Equipo
            adapter.InsertCommand.Parameters.Add("@Cod_Cia", SqlDbType.Char, 2).Value = Companhia
            adapter.InsertCommand.Parameters.Add("@CodLinNeg", SqlDbType.Char, 4).Value = Entidad.LinNeg
            adapter.InsertCommand.Parameters.Add("@CodEquipo", SqlDbType.Int).Value = Val(Entidad.Codigo)
            adapter.InsertCommand.Parameters.Add("@CodigoAnterior", SqlDbType.Char, 10).Value = Entidad.CodigoAnterior
            adapter.InsertCommand.Parameters.Add("@FamiliaEquipoID", SqlDbType.Int).Value = Entidad.FamiliaEqID
            adapter.InsertCommand.Parameters.Add("@Responsable", SqlDbType.Char, 8).Value = Entidad.CodResponsable
            adapter.InsertCommand.Parameters.Add("@Manipulador", SqlDbType.Char, 8).Value = Entidad.CodManipulador
            If Entidad.ExisteFoto = Boolean.TrueString Then
                adapter.InsertCommand.Parameters.Add("@Foto", SqlDbType.Image).Value = Entidad.Foto
            End If
            If Entidad.ExistePlano = Boolean.TrueString Then
                adapter.InsertCommand.Parameters.Add("@Plano", SqlDbType.Image).Value = Entidad.Plano
            End If
            adapter.InsertCommand.Parameters.Add("@status", SqlDbType.Char, 1).Value = Entidad.Status
            adapter.InsertCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Usuario
            adapter.InsertCommand.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = 1
            'adapter.InsertCommand.Parameters.Add("@Resultado", SqlDbType.Int).Value = 0
            Try
                lResult = New ETEquipo
                lResult.Equipo = adapter.InsertCommand.ExecuteScalar
                Call Mantto_EquipoAtributo(lResult.Equipo, cn, Trans, Ls_Atributo)
                'lResult.Respuesta = lResult.Equipo
            Catch Err As Exception
                lResult.Respuesta = 0
                Trans.Rollback()
                cn.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return 0
            Finally
                Trans.Commit()
                cn.Close()
                cn.Dispose()
            End Try
        ElseIf Entidad.Tipo = 2 Then
            adapter.UpdateCommand = New SqlCommand
            adapter.UpdateCommand.Connection = cn
            adapter.UpdateCommand.CommandText = MPA_Mantenimiento.Mantenimiento_Equipo
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure
            adapter.UpdateCommand.Transaction = Trans
            adapter.UpdateCommand.Parameters.Add("@EquipoID", SqlDbType.Int).Value = Entidad.Equipo
            adapter.UpdateCommand.Parameters.Add("@Cod_Cia", SqlDbType.Char, 2).Value = Companhia
            adapter.UpdateCommand.Parameters.Add("@CodLinNeg", SqlDbType.Char, 4).Value = Entidad.LinNeg
            adapter.UpdateCommand.Parameters.Add("@CodEquipo", SqlDbType.Int).Value = Val(Entidad.Codigo)
            adapter.UpdateCommand.Parameters.Add("@FamiliaEquipoID", SqlDbType.Int).Value = Entidad.FamiliaEqID
            adapter.UpdateCommand.Parameters.Add("@CodigoAnterior", SqlDbType.Char, 10).Value = Entidad.CodigoAnterior
            adapter.UpdateCommand.Parameters.Add("@Responsable", SqlDbType.Char, 8).Value = Entidad.CodResponsable
            adapter.UpdateCommand.Parameters.Add("@Manipulador", SqlDbType.Char, 8).Value = Entidad.CodManipulador
            If Entidad.ExisteFoto = Boolean.TrueString Then
                adapter.UpdateCommand.Parameters.Add("@Foto", SqlDbType.Image).Value = Entidad.Foto
            End If
            If Entidad.ExistePlano = Boolean.TrueString Then
                adapter.UpdateCommand.Parameters.Add("@Plano", SqlDbType.Image).Value = Entidad.Plano
            End If
            adapter.UpdateCommand.Parameters.Add("@status", SqlDbType.Char, 1).Value = Entidad.Status
            adapter.UpdateCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Usuario
            adapter.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = 2
            Try
                lResult = New ETEquipo
                lResult.Equipo = Entidad.Equipo
                adapter.UpdateCommand.ExecuteNonQuery()
                Call Mantto_EquipoAtributo(lResult.Equipo, cn, Trans, Ls_Atributo)
                Call Mantto_Equipo_ParteEq_Atrib_Valor(cn, Trans, Ls_AtributoParteEq)
                ' lResult.Respuesta = lResult.Equipo
            Catch Err As Exception
                lResult.Respuesta = 0
                Trans.Rollback()
                cn.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return 0
            Finally
                Trans.Commit()
                cn.Close()
                cn.Dispose()
            End Try
        ElseIf Entidad.Tipo = 3 Then
            adapter.UpdateCommand = New SqlCommand
            adapter.UpdateCommand.Connection = cn
            adapter.UpdateCommand.CommandText = MPA_Mantenimiento.Mantenimiento_Equipo
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure
            adapter.UpdateCommand.Transaction = Trans
            adapter.UpdateCommand.Parameters.Add("@EquipoID", SqlDbType.Int).Value = Entidad.Equipo
            adapter.UpdateCommand.Parameters.Add("@Cod_Cia", SqlDbType.Char, 2).Value = Companhia
            adapter.UpdateCommand.Parameters.Add("@status", SqlDbType.Char, 1).Value = Entidad.Status
            adapter.UpdateCommand.Parameters.Add("@User", SqlDbType.Char, 15).Value = Entidad.Usuario
            adapter.UpdateCommand.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = Entidad.Tipo
            Try
                lResult = New ETEquipo
                lResult.Equipo = Entidad.Equipo
                adapter.UpdateCommand.ExecuteNonQuery()
                'lResult.Respuesta = lResult.Equipo
            Catch Err As Exception
                lResult.Respuesta = 0
                Trans.Rollback()
                cn.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)
                Return 0
            Finally
                Trans.Commit()
                cn.Close()
                cn.Dispose()
            End Try
        End If

        Return lResult.Equipo

    End Function
    Public Function Consultar_Equipo() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 4)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Equipo = New ETEquipo
                    With Entidad.Equipo
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .LinNeg = dr.GetString(dr.GetOrdinal("LinNeg"))
                        .FamiliaEq = dr.GetString(dr.GetOrdinal("FamiliaEq"))

                        If dr.GetBoolean(dr.GetOrdinal("ExisteFoto")) = Boolean.FalseString Then
                            .ExisteFoto = Boolean.FalseString
                        Else
                            Dim byteBLOBDataFoto(-1) As [Byte]
                            byteBLOBDataFoto = CType(dr.GetValue(dr.GetOrdinal("Foto")), [Byte]())
                            .Foto = byteBLOBDataFoto
                            .ExisteFoto = Boolean.TrueString
                        End If

                        If dr.GetBoolean(dr.GetOrdinal("ExistePlano")) = Boolean.FalseString Then
                            .ExistePlano = Boolean.FalseString
                        Else
                            Dim byteBLOBDataPlano(-1) As [Byte]
                            byteBLOBDataPlano = CType(dr.GetValue(dr.GetOrdinal("Plano")), [Byte]())
                            .Plano = byteBLOBDataPlano
                            .ExistePlano = Boolean.TrueString
                        End If
                        .CodigoAnterior = dr.GetString(dr.GetOrdinal("CodigoAnterior"))
                        .Responsable = dr.GetString(dr.GetOrdinal("Responsable"))
                        .Manipulador = dr.GetString(dr.GetOrdinal("Manipulador"))
                        .CodResponsable = dr.GetString(dr.GetOrdinal("CodResponsable"))
                        .CodManipulador = dr.GetString(dr.GetOrdinal("CodManipulador"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .LinNegID = dr.GetInt32(dr.GetOrdinal("LinNegID"))
                        .Status = dr.GetString(dr.GetOrdinal("Status"))
                        .FamiliaEqID = dr.GetInt32(dr.GetOrdinal("FamiliaEqID"))
                        .Equipo = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        lResult.Ls_Equipo.Add(Entidad.Equipo)

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

    Public Function Consultar_Equipo_Activos() As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 5)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Equipo = New ETEquipo
                    With Entidad.Equipo
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .LinNeg = dr.GetString(dr.GetOrdinal("LinNeg"))
                        .FamiliaEq = dr.GetString(dr.GetOrdinal("FamiliaEq"))
                        .Equipo = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        .AtribID = dr.GetInt32(dr.GetOrdinal("AtribID"))
                        .Atributo = dr.GetString(dr.GetOrdinal("Atributo"))
                        .Und = dr.GetString(dr.GetOrdinal("Und"))
                        .TipoDato = dr.GetInt16(dr.GetOrdinal("TipoDato"))
                        .Longitud = dr.GetInt16(dr.GetOrdinal("Longitud"))
                        .Decimales = dr.GetInt16(dr.GetOrdinal("Decimales"))
                        lResult.Ls_Equipo.Add(Entidad.Equipo)
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
    Public Function Consultar_Equipo_Req(ByVal EntEq As ETEquipo) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
        Dim ds As DataSet

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "status", DbType.String, EntEq.Status)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, EntEq.Tipo)


            ds = db.ExecuteDataSet(cmd)
            'Using dr As IDataReader = db.ExecuteReader(cmd)
            '    While dr.Read
            '        Entidad.Equipo = New ETEquipo
            '        With Entidad.Equipo
            '            .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
            '            .Descripcion = Mid(dr.GetString(dr.GetOrdinal("Descripcion")), 4, Len(dr.GetString(dr.GetOrdinal("Descripcion"))))
            '            .LinNeg = dr.GetString(dr.GetOrdinal("LinNeg"))
            '            .FamiliaEq = dr.GetString(dr.GetOrdinal("FamiliaEq"))
            '            .Equipo = dr.GetInt32(dr.GetOrdinal("EquipoID"))
            '            lResult.Ls_Equipo.Add(Entidad.Equipo)
            '        End With
            '    End While
            '    If dr IsNot Nothing Then dr.Close()

            'End Using

        Catch Err As Exception

            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            ds = Nothing

        End Try

        Return ds

    End Function
    Public Function ConsultarAtributosEquipo(ByVal EntEq As ETEquipo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_EquipoAtributo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "EquipoID", DbType.Int32, EntEq.Equipo)
            db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, EntEq.FamiliaEqID)
            db.AddInParameter(cmd, "Tipo", DbType.String, EntEq.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Atributo = New ETAtributo
                    Entidad.Atributo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.Atributo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Atributo.Valor = dr.GetString(dr.GetOrdinal("Valor"))
                    Entidad.Atributo.Und = dr.GetString(dr.GetOrdinal("Und"))
                    Entidad.Atributo.TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                    Entidad.Atributo.Longitud = dr.GetString(dr.GetOrdinal("Longitud"))
                    Entidad.Atributo.Decimales = dr.GetString(dr.GetOrdinal("Decimales"))
                    Entidad.Atributo.Oblig = dr.GetBoolean(dr.GetOrdinal("Oblig"))
                    Entidad.Atributo.Control = dr.GetBoolean(dr.GetOrdinal("Control"))
                    Entidad.Atributo.NomEq = dr.GetBoolean(dr.GetOrdinal("NomEq"))
                    Entidad.Atributo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    Entidad.Atributo.IDCatalogoOrigen = dr.GetInt32(dr.GetOrdinal("IDCatalogoOrigen"))
                    Entidad.Atributo.TipoG = dr.GetBoolean(dr.GetOrdinal("Nuevo"))
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
    Public Function ConsultarAtributosEquipo_New(ByVal EntFamliaEq As ETFamiliaEquipo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo_CargarDatosNew)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "FAMILIAEQUIPOID", DbType.Int32, EntFamliaEq.IDFamiliaEq)
            db.AddInParameter(cmd, "Tipo", DbType.String, "1")

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Atributo = New ETAtributo
                    Entidad.Atributo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.Atributo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Atributo.Valor = dr.GetString(dr.GetOrdinal("Valor"))
                    Entidad.Atributo.Und = dr.GetString(dr.GetOrdinal("Und"))
                    Entidad.Atributo.TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                    Entidad.Atributo.Longitud = dr.GetString(dr.GetOrdinal("Longitud"))
                    Entidad.Atributo.Decimales = dr.GetString(dr.GetOrdinal("Decimales"))
                    Entidad.Atributo.Oblig = dr.GetBoolean(dr.GetOrdinal("Oblig"))
                    Entidad.Atributo.Control = dr.GetBoolean(dr.GetOrdinal("Control"))
                    Entidad.Atributo.NomEq = dr.GetBoolean(dr.GetOrdinal("NomEq"))
                    Entidad.Atributo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    Entidad.Atributo.IDCatalogoOrigen = dr.GetInt32(dr.GetOrdinal("IDCatalogoOrigen"))
                    Entidad.Atributo.TipoG = dr.GetBoolean(dr.GetOrdinal("Nuevo"))
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
    Public Function ConsultarAtributosParteEquipo_New(ByVal EntFamliaEq As ETFamiliaEquipo) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo_CargarDatosNew)
        Dim Ds As DataSet
        Try

            db.AddInParameter(cmd, "FAMILIAEQUIPOID", DbType.Int32, EntFamliaEq.IDFamiliaEq)
            db.AddInParameter(cmd, "Tipo", DbType.String, "2")

            Ds = db.ExecuteDataSet(cmd)
            Ds.Tables(0).TableName = "TablaArbol"
            Return Ds
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function Consultar_Equipo_ParteEquipo(ByVal EntEquipo As ETEquipo) As DataSet

        Dim db As Database = DatabaseFactory.CreateDatabase()

        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo_ParteEq)
        Dim Ds As DataSet
        Try

            db.AddInParameter(cmd, "EQUIPOID", DbType.Int32, EntEquipo.Equipo)
            db.AddInParameter(cmd, "FAMILIAEQUIPOID", DbType.Int32, EntEquipo.FamiliaEqID)
            db.AddInParameter(cmd, "Tipo", DbType.String, "4")

            Ds = db.ExecuteDataSet(cmd)
            Ds.Tables(0).TableName = "TablaArbol"
            Return Ds
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

    End Function

    Public Function ConsultarEquipo_ParteEq_Atrib_Valor(ByVal EntEq As ETAtributo) As ETMyLista
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo_ParteEq_Atrib_Valor)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "EquipoParteEq", DbType.Int32, EntEq.Nodo)
            db.AddInParameter(cmd, "Tipo", DbType.String, EntEq.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Atributo = New ETAtributo
                    Entidad.Atributo.Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                    Entidad.Atributo.Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                    Entidad.Atributo.Valor = dr.GetString(dr.GetOrdinal("Valor"))
                    Entidad.Atributo.Und = dr.GetString(dr.GetOrdinal("Und"))
                    Entidad.Atributo.TipoDato = dr.GetString(dr.GetOrdinal("TipoDato"))
                    Entidad.Atributo.Longitud = dr.GetString(dr.GetOrdinal("Longitud"))
                    Entidad.Atributo.Decimales = dr.GetString(dr.GetOrdinal("Decimales"))
                    Entidad.Atributo.Oblig = dr.GetBoolean(dr.GetOrdinal("Oblig"))
                    Entidad.Atributo.Ubicacion = dr.GetBoolean(dr.GetOrdinal("Ubicacion"))
                    Entidad.Atributo.IDCatalogo = dr.GetInt32(dr.GetOrdinal("IDCatalogo"))
                    Entidad.Atributo.IDCatalogoOrigen = dr.GetInt32(dr.GetOrdinal("IDCatalogoOrigen"))
                    Entidad.Atributo.Nuevo = dr.GetString(dr.GetOrdinal("Nuevo"))
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

    Public Function Consultar_Equipo_Por_Familia(ByVal Ent As ETEquipo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "FamiliaEquipoID", DbType.String, Ent.FamiliaEqID)
            db.AddInParameter(cmd, "EquipoID", DbType.String, Ent.Equipo)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 7)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Equipo = New ETEquipo
                    With Entidad.Equipo
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .Equipo = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        lResult.Ls_Equipo.Add(Entidad.Equipo)
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
    Public Function Consultar_Equipo_Mantenimiento(ByVal Ent_Eq As ETEquipo) As ETMyLista
        Dim lResult As ETMyLista = Nothing
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "EquipoID", DbType.Int32, Ent_Eq.Equipo)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 8)
            Using dr As IDataReader = db.ExecuteReader(cmd)
                lResult = New ETMyLista
                While dr.Read
                    Entidad.OrdenTrabajo = New ETOrdenTrabajo_Mantto
                    With Entidad.OrdenTrabajo
                        .Codigo = dr.GetString(dr.GetOrdinal("Abrev")) & "  " & dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .EncargadoArea = dr.GetString(dr.GetOrdinal("EncargadoArea"))
                        .Cod_Presp = dr.GetString(dr.GetOrdinal("Abrev")) & "  " & dr.GetString(dr.GetOrdinal("Cod_Presp"))
                        .TipoMantto = dr.GetString(dr.GetOrdinal("TipoMantto"))
                        .Moneda = dr.GetString(dr.GetOrdinal("Moneda"))
                        .CostoPresup = dr.GetDecimal(dr.GetOrdinal("CostoPresup"))
                        .CostoTotal = dr.GetDecimal(dr.GetOrdinal("CostoTotal"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("FechaInicio"))
                        .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("FechaTermino"))
                        .Estado = dr.GetString(dr.GetOrdinal("Estado"))
                        .Presupuesto = dr.GetInt32(dr.GetOrdinal("Presupuesto"))
                        .OrdenTrabajo = dr.GetInt32(dr.GetOrdinal("OrdenTrabajo"))
                    End With
                    lResult.Ls_Orden_Trabajo_Mantto.Add(Entidad.OrdenTrabajo)
                End While
                If dr IsNot Nothing Then dr.Close()
                lResult.Validacion = True
            End Using
        Catch Err As Exception
            lResult = Nothing
            MsgBox(Err.Message)

        End Try


        Return lResult
    End Function

    Public Function Validar_Equipo_Mantenimiento(ByVal Ent_Eq As ETEquipo) As Integer
        Dim lResult As Integer = 0
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "EquipoID", DbType.Int32, Ent_Eq.Equipo)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 9)

            lResult = db.ExecuteScalar(cmd)
        Catch Err As Exception
            lResult = 0
            MsgBox(Err.Message)

        End Try

        Return lResult
    End Function

    Public Function Validar_Equipo_CodigoAnterior(ByVal Ent_Eq As ETEquipo) As Boolean
        Dim lResult As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "EquipoID", DbType.Int32, Ent_Eq.Equipo)
            db.AddInParameter(cmd, "CodigoAnterior", DbType.String, Ent_Eq.CodigoAnterior)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 10)

            lResult = db.ExecuteScalar(cmd)
        Catch Err As Exception

            MsgBox(Err.Message)

        End Try

        Return lResult
    End Function

    Public Function Validar_Equipo_CodigoContabilidad(ByVal Ent_Eq As ETEquipo) As Boolean
        Dim lResult As Boolean = False
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "EquipoID", DbType.Int32, Ent_Eq.Equipo)
            db.AddInParameter(cmd, "CodigoContabilidad", DbType.String, Ent_Eq.CodigoContabilidad)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 14)

            lResult = db.ExecuteScalar(cmd)
        Catch Err As Exception

            MsgBox(Err.Message)

        End Try

        Return lResult
    End Function

    Public Function Consultar_Equipo_Contabilidad(ByVal Equipo As ETEquipo) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Equipo.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Equipo = New ETEquipo
                    With Entidad.Equipo
                        .Action = dr.GetBoolean(dr.GetOrdinal("Action"))
                        .LinNeg = dr.GetString(dr.GetOrdinal("LinNeg"))
                        .FamiliaEq = dr.GetString(dr.GetOrdinal("FamiliaEq"))
                        .Codigo = dr.GetString(dr.GetOrdinal("Codigo"))
                        .Descripcion = dr.GetString(dr.GetOrdinal("Descripcion"))
                        .CodigoAnterior = dr.GetString(dr.GetOrdinal("CodigoAnterior"))
                        .CodigoContabilidad = dr.GetString(dr.GetOrdinal("CodigoContabilidad"))
                        .Equipo = dr.GetInt32(dr.GetOrdinal("EquipoID"))
                        lResult.Ls_Equipo.Add(Entidad.Equipo)

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

    Public Function Update_Equipo_Contabilidad(ByVal ListaPendiente As List(Of ETEquipo), _
                                               ByVal ListaDesenlazar As List(Of ETEquipo)) As Integer

        Dim lResult As Long = 0
        Dim db As Database = DatabaseFactory.CreateDatabase

        Using Conexion As DbConnection = db.CreateConnection
            Conexion.Open()
            Dim Trans As DbTransaction = Conexion.BeginTransaction
            Try
                For Each xRow As ETEquipo In ListaDesenlazar
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
                    db.AddInParameter(cmd, "CodigoContabilidad", DbType.String, xRow.CodigoContabilidad)
                    db.AddInParameter(cmd, "EquipoID", DbType.String, xRow.Equipo)
                    db.AddInParameter(cmd, "User", DbType.String, xRow.Usuario)
                    db.AddInParameter(cmd, "Tipo", DbType.Int16, xRow.Tipo)

                    db.ExecuteNonQuery(cmd, Trans)
                Next

                For Each xRow As ETEquipo In ListaPendiente
                    Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Equipo)
                    db.AddInParameter(cmd, "CodigoContabilidad", DbType.String, xRow.CodigoContabilidad)
                    db.AddInParameter(cmd, "EquipoID", DbType.String, xRow.Equipo)
                    db.AddInParameter(cmd, "User", DbType.String, xRow.Usuario)
                    db.AddInParameter(cmd, "Tipo", DbType.Int16, xRow.Tipo)

                    db.ExecuteNonQuery(cmd, Trans)
                Next

                Trans.Commit()
                Conexion.Close()
                lResult = 1
            Catch Err As Exception
                Trans.Rollback()
                Conexion.Close()
                lResult = 0
                MsgBox(Err.Message, MsgBoxStyle.Critical, MsgComacsa)

            End Try

        End Using
        Return lResult

    End Function

    Public Sub New()

    End Sub
End Class
