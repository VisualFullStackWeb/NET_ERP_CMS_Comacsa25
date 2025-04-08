Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Globalization
Imports System.Configuration
Public Class DAPartida
    Public Function Mantenimiento_Partida(ByVal Ent_Part As ETPartida) As Integer
        Dim lResult As ETPartida = Nothing
        If Ent_Part Is Nothing Then
            Return Nothing
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase
        Using conexion As DbConnection = db.CreateConnection
            conexion.Open()
            Dim Trans As DbTransaction = conexion.BeginTransaction
            Try
                Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida)
                db.AddInParameter(cmd, "PartidaID", DbType.Int32, Ent_Part.Partida)
                db.AddInParameter(cmd, "PartidaPadre", DbType.Int32, Ent_Part.PartidaPadre)
                db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
                'If Not (Ent_Part.Tipo = 5) Then
                Select Case Ent_Part.Level
                    Case 1
                        db.AddInParameter(cmd, "CodLinNeg", DbType.Int16, Ent_Part.LinNeg)
                    Case 2
                        db.AddInParameter(cmd, "TipoProceso", DbType.Int16, Ent_Part.TipoProceso)
                    Case 3
                        If Ent_Part.TipoProceso = "1" Then
                            db.AddInParameter(cmd, "AtributoControlador", DbType.Int32, Ent_Part.AtributoControl)
                            db.AddInParameter(cmd, "ValorControlador", DbType.String, Ent_Part.ValorControl)
                        Else
                            db.AddInParameter(cmd, "ValorControlador", DbType.String, Ent_Part.ValorControl)
                        End If
                    Case 4
                        db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, Ent_Part.FamiliaEquipo)
                    Case 5
                        db.AddInParameter(cmd, "ManttoGeneral", DbType.Boolean, Ent_Part.ManttoGeneral)
                        db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, Ent_Part.ParteEquipo)
                End Select
                'Else
                db.AddInParameter(cmd, "Total", DbType.Double, Ent_Part.Total)
                db.AddInParameter(cmd, "UnidadMedida", DbType.String, Ent_Part.UniMed)
                db.AddInParameter(cmd, "TipoFactor", DbType.String, Ent_Part.TipoFactor)
                db.AddInParameter(cmd, "Factor", DbType.Double, Ent_Part.Factor)
                db.AddInParameter(cmd, "Jornada", DbType.Double, Ent_Part.Jornada)
                'End If
                db.AddInParameter(cmd, "Descripcion", DbType.String, Ent_Part.Descripcion)
                db.AddInParameter(cmd, "status", DbType.String, Ent_Part.Status)
                db.AddInParameter(cmd, "User", DbType.String, Ent_Part.Usuario)
                db.AddInParameter(cmd, "Level", DbType.String, Ent_Part.Level.ToString)
                db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_Part.Tipo)

                lResult = New ETPartida
                lResult.Respuesta = db.ExecuteNonQuery(cmd, Trans)
                lResult.Validacion = Boolean.TrueString
                Trans.Commit()
                conexion.Close()
            Catch Err As Exception
                lResult.Respuesta = 0
                Trans.Rollback()
                conexion.Close()
                MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

            End Try
        End Using
        Return lResult.Respuesta
    End Function

    Public Function Consultar_Partida_Duplicada(ByVal Ent_Part As ETPartida) As Integer
        Dim lResult As ETPartida = Nothing
        If Ent_Part Is Nothing Then
            Return 0
        End If
        Dim db As Database = DatabaseFactory.CreateDatabase

        Try
            Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida)
            db.AddInParameter(cmd, "PartidaID", DbType.Int32, Ent_Part.Partida)
            db.AddInParameter(cmd, "PartidaPadre", DbType.Int32, Ent_Part.PartidaPadre)
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            'If Not (Ent_Part.Tipo = 5) Then
            Select Case Ent_Part.Level
                Case 1
                    db.AddInParameter(cmd, "CodLinNeg", DbType.Int16, Ent_Part.LinNeg)
                Case 2
                    db.AddInParameter(cmd, "TipoProceso", DbType.Int16, Ent_Part.TipoProceso)
                Case 3
                    If Ent_Part.TipoProceso = "1" Then
                        db.AddInParameter(cmd, "AtributoControlador", DbType.Int32, Ent_Part.AtributoControl)
                        db.AddInParameter(cmd, "ValorControlador", DbType.String, Ent_Part.ValorControl)
                    Else
                        db.AddInParameter(cmd, "ValorControlador", DbType.String, Ent_Part.ValorControl)
                    End If
                Case 4
                    db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, Ent_Part.FamiliaEquipo)
                Case 5
                    db.AddInParameter(cmd, "ManttoGeneral", DbType.Boolean, Ent_Part.ManttoGeneral)
                    db.AddInParameter(cmd, "ParteEquipoID", DbType.Int32, Ent_Part.ParteEquipo)
            End Select
            'Else
            db.AddInParameter(cmd, "Total", DbType.Double, Ent_Part.Total)
            db.AddInParameter(cmd, "UnidadMedida", DbType.String, Ent_Part.UniMed)
            db.AddInParameter(cmd, "TipoFactor", DbType.String, Ent_Part.TipoFactor)
            db.AddInParameter(cmd, "Factor", DbType.Double, Ent_Part.Factor)
            db.AddInParameter(cmd, "Jornada", DbType.Double, Ent_Part.Jornada)
            'End If
            db.AddInParameter(cmd, "Descripcion", DbType.String, Ent_Part.Descripcion)
            db.AddInParameter(cmd, "status", DbType.String, Ent_Part.Status)
            db.AddInParameter(cmd, "User", DbType.String, Ent_Part.Usuario)
            db.AddInParameter(cmd, "Level", DbType.String, Ent_Part.Level.ToString)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 0)

            lResult = New ETPartida
            lResult.Respuesta = db.ExecuteScalar(cmd)

        Catch Err As Exception
            lResult.Respuesta = -1
            MsgBox(Err.Message & vbCrLf & msgError, MsgBoxStyle.Critical, MsgComacsa)

        End Try

        Return lResult.Respuesta
    End Function

    Public Function Consultar_Partida() As DataSet
        Dim ds As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida)
        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, "4")
            ds = db.ExecuteDataSet(cmd)
            ds.Tables(0).TableName = "TablaArbol"
            Return ds
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
    Public Function Consultar_Partida_Nodo(ByVal Ent_Part As ETPartida) As DataSet
        Dim ds As DataSet
        Dim db As Database = DatabaseFactory.CreateDatabase
        Dim cmd As DbCommand = db.GetStoredProcCommand(MPA_Mantenimiento.Mantenimiento_Partida)
        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodLinNeg", DbType.Int16, Ent_Part.LinNeg)
            db.AddInParameter(cmd, "AtributoControlador", DbType.Int32, Ent_Part.AtributoControl)
            db.AddInParameter(cmd, "FamiliaEquipoID", DbType.Int32, Ent_Part.FamiliaEquipo)
            db.AddInParameter(cmd, "PartidaID", DbType.Int32, Ent_Part.Partida)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, Ent_Part.Tipo)
            ds = db.ExecuteDataSet(cmd)
            Return ds
        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try
    End Function
End Class
