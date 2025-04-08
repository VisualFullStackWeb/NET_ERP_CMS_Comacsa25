Imports SIP_Entidad
Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports Microsoft.Practices.EnterpriseLibrary.Common
Imports System.Data.Common
Imports System.Configuration
Imports System.Globalization
Public Class DAPersonal

    Public Function ConsultarPersonal1(ByVal rpt As ETPersonal) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPersonal)
        Dim lResult As ETMyLista = Nothing

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Fecha", DbType.Date, rpt.Fecha.Date)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 1)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    With Entidad.Personal
                        .CodPersonal = dr.GetString(dr.GetOrdinal("CodPersonal"))
                        .DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("fingreso"))
                        If IsDBNull(dr.GetValue(dr.GetOrdinal("fcese"))) Then
                            .FechaTerminacion = Nothing
                        Else
                            .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("fcese"))
                        End If
                    End With
                    lResult.Ls_Personal.Add(Entidad.Personal)
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

    Public Function ConsultarPersonal2(ByVal Rpt As ETActivo) As ETMyLista


        Dim lResult As ETMyLista = Nothing
        If Rpt Is Nothing Then
            Return lResult
        End If


        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPersonal)

        Try

            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Fecha", DbType.Date, Rpt.Fecha.Date)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, 2)
            db.AddInParameter(cmd, "CodClase", DbType.String, Rpt.CodClase)
            db.AddInParameter(cmd, "CodTipo", DbType.String, Rpt.CodTipo)
            db.AddInParameter(cmd, "Placa", DbType.String, Rpt.Placa)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    With Entidad.Personal
                        .CodPersonal = dr.GetString(dr.GetOrdinal("CodPersonal"))
                        .DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                        .FechaInicio = dr.GetDateTime(dr.GetOrdinal("fingreso"))
                        If IsDBNull(dr.GetValue(dr.GetOrdinal("fcese"))) Then
                            .FechaTerminacion = Nothing
                        Else
                            .FechaTerminacion = dr.GetDateTime(dr.GetOrdinal("fcese"))
                        End If

                    End With
                    lResult.Ls_Personal.Add(Entidad.Personal)
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

    Public Function ConsultarCronograma(ByVal A As ETActivo) As List(Of ETPersonal)
        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarCronograma)
        Dim lst As New List(Of ETPersonal)
        Dim E As ETPersonal = Nothing

        Try

            db.AddInParameter(cmd, "Tipo", DbType.Int16, 3)
            db.AddInParameter(cmd, "Companhia", DbType.String, Companhia)
            db.AddInParameter(cmd, "CodClase", DbType.String, A.CodClase)
            db.AddInParameter(cmd, "CodTipo", DbType.String, A.CodTipo)
            db.AddInParameter(cmd, "Anho", DbType.Int32, A.Anho)
            db.AddInParameter(cmd, "Semana", DbType.Int16, A.Semana)
            db.AddInParameter(cmd, "dia", DbType.Int16, A.Dia)
            db.AddInParameter(cmd, "Turno", DbType.Int16, A.Turno)

            Using dr As IDataReader = db.ExecuteReader(cmd)

                While dr.Read
                    E = New ETPersonal
                    E.ID = dr.GetInt32(dr.GetOrdinal("ID"))
                    E.CodPersonal = dr.GetString(dr.GetOrdinal("CodPersonal"))
                    E.DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                    lst.Add(E)
                End While

                If Not dr Is Nothing Then
                    dr.Close()
                End If

            End Using

        Catch Err As Exception
            MsgBox(Err.Message & vbNewLine & msgError, MsgBoxStyle.Critical, MsgComacsa)
            Return Nothing
        End Try

        Return lst

    End Function

    Public Function ConsultarPersonal4(ByVal EntPers As ETPersonal) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPersonal)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, EntPers.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    With Entidad.Personal
                        .CodPersonal = dr.GetString(dr.GetOrdinal("CodPersonal"))
                        .DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                    End With
                    lResult.Ls_Personal.Add(Entidad.Personal)
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

    Public Function ConsultarPersonal5(ByVal EntPers As ETPersonal) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPersonal)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Cargo", DbType.String, EntPers.Cargo)
            db.AddInParameter(cmd, "Fecha", DbType.Date, EntPers.Fecha)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, EntPers.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    With Entidad.Personal
                        .CodPersonal = dr.GetString(dr.GetOrdinal("Codigo"))
                        .DesPersonal = dr.GetString(dr.GetOrdinal("Personal"))
                        .DescripArea = dr.GetString(dr.GetOrdinal("Area"))
                    End With
                    lResult.Ls_Personal.Add(Entidad.Personal)
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


    Public Function ConsultarPersonal_LineaProduccion(ByVal EntPers As ETPersonal) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPersonal)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "LinProd", DbType.Int32, EntPers.ID)
            db.AddInParameter(cmd, "Fecha", DbType.Date, EntPers.Fecha.ToShortDateString)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, EntPers.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    With Entidad.Personal
                        .CodPersonal = dr.GetString(dr.GetOrdinal("Codigo"))
                        .DesPersonal = dr.GetString(dr.GetOrdinal("Descripcion"))
                    End With
                    lResult.Ls_Personal.Add(Entidad.Personal)
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

    Public Function ConsultarPersonal7(ByVal EntPers As ETPersonal) As ETMyLista

        Dim db As Database = DatabaseFactory.CreateDatabase()
        Dim cmd As DbCommand = db.GetStoredProcCommand(PPA_Produccion.ConsultarPersonal)
        Dim lResult As ETMyLista = Nothing

        Try
            db.AddInParameter(cmd, "Cod_Cia", DbType.String, Companhia)
            db.AddInParameter(cmd, "Fecha", DbType.DateTime, EntPers.Fecha)
            db.AddInParameter(cmd, "Tipo", DbType.Int16, EntPers.Tipo)

            lResult = New ETMyLista

            Using dr As IDataReader = db.ExecuteReader(cmd)
                While dr.Read
                    Entidad.Personal = New ETPersonal
                    With Entidad.Personal
                        .CodPersonal = dr.GetString(dr.GetOrdinal("placod"))
                        .DesPersonal = dr.GetString(dr.GetOrdinal("DesPersonal"))
                    End With
                    lResult.Ls_Personal.Add(Entidad.Personal)
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
